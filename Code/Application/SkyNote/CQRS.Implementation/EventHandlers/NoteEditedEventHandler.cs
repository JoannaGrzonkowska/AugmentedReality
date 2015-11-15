using CQRS.EventHandlers;
using CQRS.Events;
using CQRS.Implementation.Events;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;
using System.Linq;

namespace CQRS.Implementation.EventHandlers
{
    public class NoteEditedEventHandler : IEventHandler<NoteEditedEvent>
    {
        private readonly INoteDenormalizedRepository noteDenormalizedRepository;

        public NoteEditedEventHandler(INoteDenormalizedRepository noteDenormalizedRepository)
        {
            this.noteDenormalizedRepository = noteDenormalizedRepository;
        }
        public void Handle(NoteEditedEvent handle)
        {
            var note = noteDenormalizedRepository.GetAllQueryable().FirstOrDefault(x => x.NoteId == handle.NoteId);
            note.Content = handle.Content;
            note.Topic = handle.Topic;
            note.Date = handle.Date;

            noteDenormalizedRepository.SaveChanges();
        }
    }
}

