using CQRS.CommandHandlers;
using CQRS.Commands;

namespace CQRS.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : ICommand;
    }
}
