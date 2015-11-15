using CQRS.Events;
using System;

namespace CQRS.Implementation.Events
{
    public class NoteDeletedEvent : Event
    {
        public int NoteId { get; set; }
    }
}
