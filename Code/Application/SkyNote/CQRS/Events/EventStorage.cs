using CQRS.Messaging;
using System;

namespace CQRS.Events
{
    public class EventStorage : IEventStorage
    {
        private readonly IEventBus eventBus;
        public EventStorage(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public void Publish(Event @event)
        {
            dynamic desEvent = Convert.ChangeType(@event, @event.GetType());
            eventBus.Publish(desEvent);
        }
    }
}
