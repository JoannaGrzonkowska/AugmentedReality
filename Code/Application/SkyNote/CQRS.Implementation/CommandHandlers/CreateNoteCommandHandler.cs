using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess;
using DataAccess.Repositories;
using System;

namespace CQRS.Implementation.CommandHandlers
{
    public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand>
    {
        private INoteRepository repository;
        private IEventStorage eventStorage;

        public CreateNoteCommandHandler(INoteRepository repository, IEventStorage eventStorage)
        {
            this.repository = repository;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(CreateNoteCommand command)
        {
            var note = command.Build();

            repository.Add(note);
            repository.SaveChanges();
            eventStorage.Publish(
                new NoteCreatedEvent(note.Id, (int)note.UserId, (int)note.LocationId, note.Topic, note.Content));

            return new CommandResult();

        }
    }
}
