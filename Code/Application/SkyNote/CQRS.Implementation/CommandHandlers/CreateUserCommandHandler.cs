using CQRS.CommandHandlers;
using CQRS.Implementation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Commands;
using DataAccess.Repositories;
using CQRS.Events;

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
            //TODO : EVENT?

            return new CommandResult();
        }
    }
}
