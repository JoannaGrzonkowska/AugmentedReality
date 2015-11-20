using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;

namespace CQRS.Implementation.CommandHandlers
{
    public class DeleteGroupCommandHandler : ICommandHandler<DeleteGroupCommand>
    {
        private IGroupRepository groupRepository;
        private IEventStorage eventStorage;

        public DeleteGroupCommandHandler(IGroupRepository groupRepository, IEventStorage eventStorage)
        {
            this.groupRepository = groupRepository;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(DeleteGroupCommand command)
        {
            var group = this.groupRepository.GetById(command.GroupId);
            if(group != null)
            {
                this.groupRepository.Delete(group);
                this.groupRepository.SaveChanges();

                this.eventStorage.Publish(new GroupDeletedEvent() { GroupId = group.Id });

                return new CommandResult();
            }
            else
            {
                return new CommandResult(new[] { "Group does not exists." });
            }
        }
    }
}
