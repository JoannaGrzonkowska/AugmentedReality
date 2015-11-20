using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess;
using DataAccess.Repositories;

namespace CQRS.Implementation.CommandHandlers
{
    public class DeleteNoteCommandHandler : ICommandHandler<DeleteNoteCommand>
    {
        private INoteRepository noteRepository;
        private IEventStorage eventStorage;

        public DeleteNoteCommandHandler(INoteRepository noteRepository, IEventStorage eventStorage)
        {
            this.noteRepository = noteRepository;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(DeleteNoteCommand command)
        {
            var note = noteRepository.GetById(command.NoteId);
            if (note != null)
            {
                noteRepository.Delete(note);
                noteRepository.SaveChanges();

                eventStorage.Publish(new NoteDeletedEvent() { NoteId = note.Id });

                return new CommandResult();
            }
            else
            {
                return new CommandResult(new []{"Note does not exists."});
            }

        }
    }
}
