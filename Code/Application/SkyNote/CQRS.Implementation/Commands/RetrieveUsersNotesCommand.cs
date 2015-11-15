using CQRS.Commands;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Commands
{
    public class RetrieveUsersNotesCommand : Command<note>
    {
        public int UserId { get; set; }

        public override note Build(note userNotes = null, Action<note> additionalAction = null)
        {
            Action<note> action = x =>
            {
                x.UserId = UserId;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(userNotes, action);
        }
    }
}
