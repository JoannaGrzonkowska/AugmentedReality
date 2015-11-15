using CQRS.EventHandlers;
using CQRS.Events;
using CQRS.Implementation.Events;
using DataAccess.Repositories;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;
using System.Linq;

namespace CQRS.Implementation.EventHandlers
{
    public class NoteCreatedEventHandler : IEventHandler<NoteCreatedEvent>
    {
        private readonly INoteDenormalizedRepository noteDenormalizedRepository;
        private readonly IUserRepository _userRepository;

        public NoteCreatedEventHandler(INoteDenormalizedRepository noteDenormalizedRepository, IUserRepository userRepository)
        {
            this.noteDenormalizedRepository =  noteDenormalizedRepository;
            _userRepository = userRepository;
        }
        public void Handle(NoteCreatedEvent handle)
        {
            var user = _userRepository.GetById(handle.UserId);
            var item = new note()
            {
                NoteId = handle.NoteId,
                Content = handle.Content,
                Topic = handle.Topic,
                UserId = handle.UserId,
                LocationId = handle.LocationId,
                Date = handle.Date,
                XCord = handle.XCord,
                YCord = handle.YCord,
                ZCord = handle.ZCord,
                Login = user.Login,
                Mail = user.Mail,
                Name = user.Name
            };

            noteDenormalizedRepository.Add(item);
            noteDenormalizedRepository.SaveChanges();
        }
    }
}

