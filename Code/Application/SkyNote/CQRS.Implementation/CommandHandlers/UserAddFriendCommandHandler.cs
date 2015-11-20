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
    public class UserAddFriendCommandHandler : ICommandHandler<UserAddFriendCommand>
    {
        private IUserfriendsRepository userfriendStorage;
        private IUserRepository userStorage;
        private IEventStorage eventStorage;

        public UserAddFriendCommandHandler(IUserfriendsRepository userfriendStorage, IUserRepository userStorage, IEventStorage eventStorage)
        {
            this.userfriendStorage = userfriendStorage;
            this.userStorage = userStorage;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(UserAddFriendCommand command)
        {
            var userfriend = command.Build();

            userfriendStorage.Add(userfriend);
            userfriendStorage.SaveChanges();
            
            IQueryable<user> users = this.userStorage.RetriveUserById(command.UserId);
            IQueryable<user> friends = this.userStorage.RetriveUserById(command.FriendId);

            if (users!=null && friends != null)
            {
                user currentUser = users.First();
                user currentFriend = friends.First();

                eventStorage.Publish(new UserAddFriendEvent(
                    userfriend.UserId, currentUser.Name, currentUser.Login, currentUser.Mail,
                    userfriend.FriendId, currentFriend.Name, currentFriend.Login, currentFriend.Mail
                    ));
            }
            return new CommandResult();
        }
    }
}
