using CQRS.EventHandlers;
using CQRS.Events;
using System.Collections.Generic;

namespace CQRS.Utils
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event;
    }
}
