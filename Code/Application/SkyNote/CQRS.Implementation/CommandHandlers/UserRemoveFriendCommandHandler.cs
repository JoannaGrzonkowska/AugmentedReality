using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.CommandHandlers
{
    public class UserRemoveFriendCommandHandler : ICommandHandler<UserRemoveFriendCommand>
    {
        private IUserfriendsRepository _userfriendStorage;
        private IUserRepository _userStorage;
        private IEventStorage _eventStorage;

        public UserRemoveFriendCommandHandler(IUserfriendsRepository userfriendStorage, 
                                            IUserRepository userStorage, 
                                            IEventStorage eventStorage)
        {
            _userfriendStorage = userfriendStorage;
            _userStorage = userStorage;
            _eventStorage = eventStorage;
        }

        public CommandResult Execute(UserRemoveFriendCommand command)
        {
            var userfriend1 = _userfriendStorage.RetriveUserFriendsPairsByUserId(command.UserId);
            var userfriend2 = _userfriendStorage.RetriveUserFriendsPairsByUserId(command.FriendId);
            if (userfriend1 != null && userfriend2 != null)
            {
                _userfriendStorage.Delete(userfriend1);
                _userfriendStorage.Delete(userfriend2);
                _userfriendStorage.SaveChanges();

                _eventStorage.Publish(new UserRemoveFriendEvent(command.UserId, command.FriendId));
                _eventStorage.Publish(new UserRemoveFriendEvent(command.FriendId, command.UserId));

                return new CommandResult();
            }
            else
            {
                return new CommandResult(new[] { "That friendship does not exists." });
            }
        }
    }
}
