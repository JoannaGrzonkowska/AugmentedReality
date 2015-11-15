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
        private IUserRepository userRepository;
        private INoteRepository noteRepository;
        private ILocationRepository locationRepository;
        private IEventStorage eventStorage;

        public CreateNoteCommandHandler(IUserRepository userRepository, INoteRepository noteRepository, ILocationRepository locationRepository, IEventStorage eventStorage)
        {
            this.userRepository = userRepository;
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

            var note = command.Build(additionalAction: x => x.LocationId = location.LocationId);

            noteRepository.Add(note);
            noteRepository.SaveChanges();

            //retriving user data (login, mail, name)
            var user = userRepository.GetById(command.UserId);

            eventStorage.Publish(
                new NoteCreatedEvent(//TODO - ADD DATETIME
                    note.Id, (int)note.UserId, null, 
                    (int)note.LocationId, command.xCord, command.yCord, command.zCord, 
                    note.Topic, note.Content,
                    user.Name, user.Login, user.Mail));

            return new CommandResult();

        }
    }
}
