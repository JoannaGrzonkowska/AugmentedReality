using CQRS.CommandHandlers;
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

        public void Execute(CreateNoteCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            var note = new note
            {
                Id = command.Id,
                Topic = command.Topic,
                Content = command.Content,
                Date = DateTime.Now,
                LocationId = command.LocationId,
                UserId = command.UserId
            };
            //aggregate.Version = -1;
            //repository.Save(aggregate, aggregate.Version);
            repository.Add(note);
            repository.SaveChanges();
            eventStorage.Publish(
                new NoteCreatedEvent(note.Id, (int)note.UserId, (int)note.LocationId, note.Topic, note.Content));


        }
    }
}
