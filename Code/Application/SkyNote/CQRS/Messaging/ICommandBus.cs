using CQRS.Commands;

namespace CQRS.Messaging
{
    public interface ICommandBus
    {
        CommandResult Send<T>(T command) where T : ICommand;
    }
}
