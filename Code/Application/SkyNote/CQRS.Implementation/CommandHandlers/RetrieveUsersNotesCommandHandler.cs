using CQRS.CommandHandlers;
using CQRS.Implementation.Commands;
using System;
using CQRS.Commands;
using DataAccessDenormalized.Repository;

namespace CQRS.Implementation.CommandHandlers
{
    public class RetrieveUsersNotesCommandHandler : ICommandHandler<RetrieveUsersNotesCommand>
    {
        private INoteDenormalizedRepository NoteDenormRepository;

        public RetrieveUsersNotesCommandHandler(INoteDenormalizedRepository noteDenormRepository)
        {
            this.NoteDenormRepository = noteDenormRepository;
        }

        public CommandResult Execute(RetrieveUsersNotesCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
