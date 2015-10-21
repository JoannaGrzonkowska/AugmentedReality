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
            notedto item = new notedto()
            {
                Id = handle.AggregateId,
                Content = handle.Content,
                Topic = handle.Topic,
                UserId = handle.UserId,
                LocationId = handle.LocationId,
               // Version = handle.Version
            };

            noteDenormalizedRepository.Add(item);
            noteDenormalizedRepository.SaveChanges();
        }
    }
}

