using CQRS.Events;
using System;

namespace CQRS.Implementation.Events
{
    public class NoteCreatedEvent : Event
    {
        public int UserId { get; set; }
        public int NoteId { get; set; }
        public int? TypeId { get; set; }
        public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public decimal? XCord { get; set; }
        public decimal? YCord { get; set; }
        public decimal? ZCord { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }

        public NoteCreatedEvent() { }
    }
}
