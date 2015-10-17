namespace CQRS.Events
{
    public interface IEventStorage
    {
        void Publish(Event @event);
    }
}
