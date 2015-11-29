using CQRS.CommandHandlers;
using CQRS.Implementation.Commands;
using System;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Events;
using StructureMap.AutoMocking;
using DataAccess;

namespace CQRS.Implementation.CommandHandlers
{
    public class DecideFriendInviteCommandHandler : ICommandHandler<DecideFriendInviteCommand>
    {
        private IUserFriendInvitesRepository friendInvitesRepository;
        private IUserfriendsRepository userfriendStorage;
        private IUserRepository userStorage;
        private IEventStorage eventStorage;

        public DecideFriendInviteCommandHandler(IUserFriendInvitesRepository friendInvitesRepository, IUserfriendsRepository userfriendStorage, IUserRepository userStorage, IEventStorage eventStorage)
        {
            this.friendInvitesRepository = friendInvitesRepository;
            this.userfriendStorage = userfriendStorage;
            this.eventStorage = eventStorage;
            this.userStorage = userStorage;
        }

        public CommandResult Execute(DecideFriendInviteCommand command)
        {
            var friendInvite = friendInvitesRepository.GetParticularInvite(command.InvatedUserId, command.InvatingUserId);
            var friendInviteDecided = command.Build(friendInvite);
            friendInvitesRepository.SaveChanges();

            if(command.State == "ACCEPT")
            {
                userfriends friendship1 = new userfriends() { UserId = command.InvatingUserId, FriendId = command.InvatedUserId };
                userfriends friendship2 = new userfriends() { UserId = command.InvatedUserId, FriendId = command.InvatingUserId };
                userfriendStorage.Add(friendship1);
                userfriendStorage.Add(friendship2);
                userfriendStorage.SaveChanges();

                IQueryable<user> users = this.userStorage.RetriveUserById(command.InvatingUserId);
                IQueryable<user> friends= this.userStorage.RetriveUserById(command.InvatedUserId);

                if (users != null && friends != null)
                {
                    user currentUser = users.First();
                    user currentFriend = friends.First();

                    eventStorage.Publish(new UserAddFriendEvent(
                        currentUser.UserID, currentUser.Name, currentUser.Login, currentUser.Mail,
                        currentFriend.UserID, currentFriend.Name, currentFriend.Login, currentFriend.Mail
                        ));
                    eventStorage.Publish(new UserAddFriendEvent(
                        currentFriend.UserID, currentFriend.Name, currentFriend.Login, currentFriend.Mail,
                        currentUser.UserID, currentUser.Name, currentUser.Login, currentUser.Mail
                        ));
                }
            }

            eventStorage.Publish(
                new FriendInviteDecideddEvent()
                {
                    State = command.State,
                    InvitedId = command.InvatedUserId,
                    InvitingId = command.InvatingUserId
                }
            );
            return new CommandResult();
        }
    }
}
