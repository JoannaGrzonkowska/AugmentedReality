using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class NoteDeletedEvent : Event
    {
        public int NoteId { get; set; }
    }
}
