using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class GroupCreatedEvent : Event
    {
        public string Name { get; set; }
        public int UserId { get; set; }

        public GroupCreatedEvent(int groupId, string name)
        {
            AggregateId = groupId;
            Name = name;
        }
    }
}
