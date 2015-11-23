using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;

namespace CQRS.Implementation.CommandHandlers
{
    public class EditNoteCommandHandler : ICommandHandler<EditNoteCommand>
    {
        private INoteRepository noteRepository;
        private IEventStorage eventStorage;

        public EditNoteCommandHandler(INoteRepository noteRepository, IEventStorage eventStorage)
        {
            this.noteRepository = noteRepository;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(EditNoteCommand command)
        {
            var note = noteRepository.GetById(command.NoteId);
            var noteEdited = command.Build(note);

            noteRepository.SaveChanges();
            eventStorage.Publish(
                new NoteEditedEvent() {
                    NoteId = noteEdited.Id,
                    Topic = noteEdited.Topic,
                    Content = noteEdited.Content,
                    TypeId = noteEdited.TypeId,
                    Date = noteEdited.Date });

            return new CommandResult();

        }
    }
}
