using CQRS.Events;
using System;

namespace CQRS.Implementation.Events
{
    public class NoteEditedEvent : Event
    {
        public int NoteId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int? TypeId { get; set; }
    }
}
