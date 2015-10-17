using System;

namespace CQRS.Events
{
    public interface IEvent
    {
        int Id { get; }
    }
}
