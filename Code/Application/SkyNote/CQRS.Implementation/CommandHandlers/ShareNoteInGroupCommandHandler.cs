using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;

namespace CQRS.Implementation.CommandHandlers
{
    public class ShareNoteInGroupCommandHandler : ICommandHandler<ShareNoteInGroupCommand>
    {
        private IEventStorage _eventStorage;
        private INotegroupRepository _notegroupRepository;

        public ShareNoteInGroupCommandHandler(IEventStorage eventStorage, INotegroupRepository notegroupRepository)
        {
            _eventStorage = eventStorage;
            _notegroupRepository = notegroupRepository;
        }

        public CommandResult Execute(ShareNoteInGroupCommand command)
        {
            var notessgroups = command.Build();
            _notegroupRepository.Add(notessgroups);
            _notegroupRepository.SaveChanges();
            
            _eventStorage.Publish(new ShareNoteInGroupEvent(command.NoteId, command.GroupId, command.UserId));
        
            return new CommandResult();
        }
    }
}
