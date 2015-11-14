using CQRS.Commands;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Commands
{
    public class UserJoinGroupCommand : Command<usergroup>
    {
        public int RecordId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public override usergroup Build(usergroup usergroup = null, Action<usergroup> additionalAction = null)
        {
            Action<usergroup> action = x =>
            {
                x.RecordId = RecordId;
                x.UserId = UserId;
                x.GroupId = GroupId;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(usergroup, action);
        }


    }
}
