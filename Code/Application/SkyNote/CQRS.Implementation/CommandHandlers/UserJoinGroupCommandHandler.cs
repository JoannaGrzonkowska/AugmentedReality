using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;

namespace CQRS.Implementation.CommandHandlers
{
    public class UserJoinGroupCommandHandler : ICommandHandler<UserJoinGroupCommand>
    {
        private IUsergroupRepository usegroupRepository;
        private IUserRepository userRepository;
        private IGroupRepository groupRepository;
        private IEventStorage eventStorage;

        public UserJoinGroupCommandHandler(IUsergroupRepository usegroupRepository, IUserRepository userRepository, IGroupRepository groupRepository, IEventStorage eventStorage)
        {
            this.usegroupRepository = usegroupRepository;
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(UserJoinGroupCommand command)
        {
            var usergroup = command.Build();

            usegroupRepository.Add(usergroup);
            usegroupRepository.SaveChanges();

            //Retriving user's and group's data (like : name)
            var user = this.userRepository.GetById(usergroup.UserId);
            var group = this.groupRepository.GetById(usergroup.GroupId);

            if (user != null && group != null)
            {
                eventStorage.Publish(new UserJoinGroupEvent(
                    usergroup.UserId, usergroup.GroupId, "Member",
                    group.Name, user.Name, user.Login, user.Mail
                    ));
            }

            return new CommandResult();
        }

    }
}
