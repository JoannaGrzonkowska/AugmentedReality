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

        public void Send<T>(T command) where T : Command
        {
            var handler = commandHandlerFactory.GetHandler<T>();
            if (handler != null)
            {
                handler.Execute(command);
            }
            else
            {
                throw new UnregisteredDomainCommandException("no handler registered");
            }
        }
    }
}
