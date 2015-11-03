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
        private IGroupRepository repository;
        private IEventStorage eventStorage;

        public CreateGroupCommandHandler(IGroupRepository repository, IEventStorage eventStorage)
        {
            this.repository = repository;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(CreateGroupCommand command)
        {
            var group = command.Build();

            repository.Add(group);
            repository.SaveChanges();
            eventStorage.Publish(
                new GroupCreatedEvent(group.Id, group.Name));

            return new CommandResult();

        }
    }
}
