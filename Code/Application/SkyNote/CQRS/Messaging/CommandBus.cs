using Common.Exceptions;
using CQRS.Commands;
using CQRS.Utils;

namespace CQRS.Messaging
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            this.commandHandlerFactory = commandHandlerFactory;
        }

        public CommandResult Send<T>(T command) where T : ICommand
        {
            var handler = commandHandlerFactory.GetHandler<T>();
            if (handler != null)
            {
                return handler.Execute(command);
            }
           return new CommandResult(new[] {"no handler registered"});
        }
    }
}
