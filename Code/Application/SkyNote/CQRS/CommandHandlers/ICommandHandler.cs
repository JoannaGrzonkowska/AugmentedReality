using CQRS.Commands;

namespace CQRS.CommandHandlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        CommandResult Execute(TCommand command);
    
    }
}
