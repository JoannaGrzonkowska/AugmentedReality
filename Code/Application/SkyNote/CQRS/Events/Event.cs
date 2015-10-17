using System;

namespace CQRS.Events
{
    [Serializable]
    public class Event : IEvent
    {
        //public int Version;
        public int AggregateId { get; set; }
        public int Id { get; private set; }
    }
}
