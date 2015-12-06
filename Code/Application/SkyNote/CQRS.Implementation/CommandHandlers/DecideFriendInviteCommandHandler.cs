using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess;
using DataAccess.Repositories;
using System.Linq;

namespace CQRS.Implementation.CommandHandlers
{
    public class DecideFriendInviteCommandHandler : ICommandHandler<DecideFriendInviteCommand>
    {
        private IUsergroupRepository userGroupStorage;
        private IGroupRepository groupRepository;
        private IUserfriendgroupRepository userfriendgroupRepository;
        private IUserFriendInvitesRepository friendInvitesRepository;
        private IUserfriendsRepository userfriendStorage;
        private IUserRepository userStorage;
        private IEventStorage eventStorage;

        public DecideFriendInviteCommandHandler(IUsergroupRepository userGroupStorage , IGroupRepository groupRepository, IUserfriendgroupRepository userfriendgroupRepository, IUserFriendInvitesRepository friendInvitesRepository, IUserfriendsRepository userfriendStorage, IUserRepository userStorage, IEventStorage eventStorage)
        {
            this.userGroupStorage = userGroupStorage;
            this.groupRepository = groupRepository;
            this.userfriendgroupRepository = userfriendgroupRepository;
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

                //NEW-WAY
                var userfriendgroupPair1 = userfriendgroupRepository.GetAllQueryable().FirstOrDefault
                                        (x => x.UserId == command.InvatingUserId);
                var userfriendgroupPair2 = userfriendgroupRepository.GetAllQueryable().FirstOrDefault
                                        (x => x.UserId == command.InvatedUserId);
                if (userfriendgroupPair1 != null && userfriendgroupPair2 != null)
                {
                    userGroupStorage.Add(new usergroup() { UserId = command.InvatedUserId, GroupId = userfriendgroupPair1.GroupId });
                    userGroupStorage.Add(new usergroup() { UserId = command.InvatingUserId, GroupId = userfriendgroupPair2.GroupId });
                    userGroupStorage.SaveChanges();

                    IQueryable<user> users = userStorage.RetriveUserById(command.InvatingUserId);
                    IQueryable<user> friends = userStorage.RetriveUserById(command.InvatedUserId);
                    group usersFriendGroup = groupRepository.GetAllQueryable().FirstOrDefault
                                            (x => x.Id == userfriendgroupPair1.GroupId);
                    group friendFriendGroup = groupRepository.GetAllQueryable().FirstOrDefault
                                            (x => x.Id == userfriendgroupPair2.GroupId);


                    if (users != null && friends != null && usersFriendGroup != null && friendFriendGroup != null)
                    {
                        user currentUser = users.First();
                        user currentFriend = friends.First();
                       

                        //NEW-WAY
                        eventStorage.Publish(new UserJoinGroupEvent(currentUser.UserID, friendFriendGroup.Id, "MEMBER",
                        friendFriendGroup.Name, currentUser.Name, currentUser.Login, currentUser.Mail));
                        eventStorage.Publish(new UserJoinGroupEvent(currentFriend.UserID, usersFriendGroup.Id, "MEMBER",
                        usersFriendGroup.Name, currentFriend.Name, currentFriend.Login, currentFriend.Mail));
                    }
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
