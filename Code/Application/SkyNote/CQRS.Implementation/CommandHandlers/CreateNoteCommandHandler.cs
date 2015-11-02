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
        private INoteRepository noteRepository;
        private ILocationRepository locationRepository;
        private IEventStorage eventStorage;

        public CreateNoteCommandHandler(INoteRepository noteRepository, ILocationRepository locationRepository, IEventStorage eventStorage)
        {
            this.noteRepository = noteRepository;
            this.locationRepository = locationRepository;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(CreateNoteCommand command)
        {
            var location = locationRepository.GetByCord(command.xCord, command.yCord);
            if (location == null)
            {
                location = new location()
                {
                    XCord = command.xCord,
                    YCord = command.yCord,
                    ZCord = command.zCord
                };
                locationRepository.Add(location);
                locationRepository.SaveChanges();
            }

            var note = command.Build(action: x => x.LocationId = location.LocationId);

            noteRepository.Add(note);
            noteRepository.SaveChanges();
            eventStorage.Publish(
                new NoteCreatedEvent(note.Id, (int)note.UserId, (int)note.LocationId, note.Topic, note.Content));

            return new CommandResult();

        }
    }
}
