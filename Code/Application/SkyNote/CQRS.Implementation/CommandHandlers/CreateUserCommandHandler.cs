using CQRS.CommandHandlers;
using CQRS.Implementation.Commands;
using CQRS.Commands;
using DataAccess.Repositories;

namespace CQRS.Implementation.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private IUserRepository repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public CommandResult Execute(CreateUserCommand command)
        {
            var user = command.Build();

            repository.Add(user);
            repository.SaveChanges();

            return new CommandResult();
        }
    }
}
