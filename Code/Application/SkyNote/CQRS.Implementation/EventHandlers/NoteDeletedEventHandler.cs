using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized.Repository;
using System.Linq;

namespace CQRS.Implementation.EventHandlers
{
    public class NoteDeletedEventHandler : IEventHandler<NoteDeletedEvent>
    {
        private readonly INoteDenormalizedRepository noteDenormalizedRepository;

        public NoteDeletedEventHandler(INoteDenormalizedRepository noteDenormalizedRepository)
        {
            this.noteDenormalizedRepository = noteDenormalizedRepository;
        }
        public void Handle(NoteDeletedEvent handle)
        {
            var note = noteDenormalizedRepository.GetAllQueryable().FirstOrDefault(x => x.NoteId == handle.NoteId);

            noteDenormalizedRepository.Delete(note);
            noteDenormalizedRepository.SaveChanges();
        }
    }
}

