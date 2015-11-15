using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;

namespace CQRS.Implementation.CommandHandlers
{
    public class CreateGroupCommandHandler : ICommandHandler<CreateGroupCommand>
    {
        private IGroupRepository groupRepository;
        private IEventStorage eventStorage;
        private IUserRepository userRepository;

        public CreateGroupCommandHandler(IGroupRepository repository, IEventStorage eventStorage, IUserRepository userRepository)
        {
            this.groupRepository = repository;
            this.eventStorage = eventStorage;
            this.userRepository = userRepository;
        }

        public CommandResult Execute(CreateGroupCommand command)
        {
            var group = command.Build();

            groupRepository.Add(group);
            groupRepository.SaveChanges();

            var user = userRepository.GetById(command.UserId);

            eventStorage.Publish(
                new GroupCreatedEvent(group.Id, group.Name, "Creator",
                user.UserID, user.Name, user.Login, user.Mail));

            return new CommandResult();
        }
    }
}
