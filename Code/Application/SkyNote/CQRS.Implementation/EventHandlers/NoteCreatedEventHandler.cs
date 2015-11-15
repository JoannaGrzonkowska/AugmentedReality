using CQRS.EventHandlers;
using CQRS.Events;
using CQRS.Implementation.Events;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;

namespace CQRS.Implementation.EventHandlers
{
    public class NoteCreatedEventHandler : IEventHandler<NoteCreatedEvent>
    {
        private readonly INoteDenormalizedRepository noteDenormalizedRepository;

        public NoteCreatedEventHandler(INoteDenormalizedRepository noteDenormalizedRepository)
        {
            this.noteDenormalizedRepository =  noteDenormalizedRepository;
        }
        public void Handle(NoteCreatedEvent handle)
        {
            var item = new note()
            {
                Id = handle.AggregateId,
                Content = handle.Content,
                Topic = handle.Topic,
                UserId = handle.UserId,
                LocationId = handle.LocationId,
                XCord = handle.XCord,
                ZCord = handle.ZCord,
                YCord = handle.YCord,
                Date = handle.Date,
                Name = handle.Name,
                Login = handle.Login,
                Mail = handle.Mail,
                Identyfication = "NOTE"
            };

            noteDenormalizedRepository.Add(item);
            noteDenormalizedRepository.SaveChanges();
        }
    }
}

