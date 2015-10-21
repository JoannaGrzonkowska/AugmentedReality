using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class NoteCreatedEvent : Event
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }

        public NoteCreatedEvent(int id, int userId, int locationId, string topic,
            string content)
        {
            AggregateId = id;
            UserId = userId;
            LocationId = locationId;
            Topic = topic;
            Content = content;
        }
    }
}
