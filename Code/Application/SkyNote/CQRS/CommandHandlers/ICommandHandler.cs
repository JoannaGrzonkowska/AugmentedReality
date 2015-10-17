using CQRS.Commands;

namespace CQRS.CommandHandlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : Command
    { 
        void Execute(TCommand command);
    
    }
}
