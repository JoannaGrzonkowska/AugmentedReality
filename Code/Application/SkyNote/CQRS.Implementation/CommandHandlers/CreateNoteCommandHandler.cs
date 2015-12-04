using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

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
            IQueryable<user> auth_users = userRepository.RetriveUserById(command.Authentication_UserId);
            if (auth_users != null)
            {
                if (auth_users.First().Name == command.Authentication_UserName)
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

                    eventStorage.Publish(
                        new NoteCreatedEvent()
                        {
                            NoteId = note.Id,
                            UserId = note.UserId.Value,
                            LocationId = note.LocationId.Value,
                            Topic = note.Topic,
                            Content = note.Content,
                            Date = note.Date,
                            XCord = location.XCord,
                            YCord = location.YCord,
                            ZCord = location.ZCord,
                            TypeId = note.TypeId
                        });

                    return new CommandResult();
                }
            }
            return new CommandResult(new List<string>() { "Unable to authenticate user" });
        }
    }
}
