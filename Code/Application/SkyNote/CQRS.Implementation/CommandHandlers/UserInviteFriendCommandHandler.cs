using CQRS.CommandHandlers;
using CQRS.Events;
using CQRS.Implementation.Commands;
using DataAccess.Repositories;
using System.Linq;
using CQRS.Commands;
using DataAccess;
using CQRS.Implementation.Events;

namespace CQRS.Implementation.CommandHandlers
{
    public class UserInviteFriendCommandHandler : ICommandHandler<UserInviteFriendCommand>
    {
        private IUserFriendInvitesRepository userFriendInvitesStorage;
        private IUserRepository userStorage;
        private IEventStorage eventStorage;

        public UserInviteFriendCommandHandler(IUserFriendInvitesRepository userFriendInvitesStorage, IUserRepository userStorage, IEventStorage eventStorage)
        {
            this.userFriendInvitesStorage = userFriendInvitesStorage;
            this.userStorage = userStorage;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(UserInviteFriendCommand command)
        {
            var userfriendinv = command.Build();

            userFriendInvitesStorage.Add(userfriendinv);
            userFriendInvitesStorage.SaveChanges();

            IQueryable<user> users = userStorage.RetriveUserById(command.UserId);
            IQueryable<user> friends = userStorage.RetriveUserById(command.FriendId);

            if (users != null && friends != null)
            {
                user currentUser = users.First();
                user currentFriend = friends.First();

                eventStorage.Publish(new UserFriendInviteEvent(
                    currentUser.UserID, currentUser.Name, currentUser.Login, currentUser.Mail,
                    currentFriend.UserID, currentFriend.Name, currentFriend.Login, currentFriend.Mail
                    ));
            }
            return new CommandResult();
        }
    }
}
