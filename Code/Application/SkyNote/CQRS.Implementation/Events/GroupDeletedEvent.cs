using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class GroupDeletedEvent : Event
    {
        public int GroupId { get; set; }
    }
}
