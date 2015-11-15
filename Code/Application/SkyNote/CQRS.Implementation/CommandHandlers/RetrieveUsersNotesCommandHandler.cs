using CQRS.CommandHandlers;
using CQRS.Implementation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //IT SHOUDNT BE HERE
            throw new NotImplementedException();
        }
    }
}
