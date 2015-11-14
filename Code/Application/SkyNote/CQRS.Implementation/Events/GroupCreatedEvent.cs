using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class GroupCreatedEvent : Event
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }

        public GroupCreatedEvent(int groupId, string name, string role)
        {
            AggregateId = groupId;
            Name = name;
            Role = role;
        }
    }
}
