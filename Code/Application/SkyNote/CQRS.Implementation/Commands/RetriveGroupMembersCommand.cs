using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class RetriveGroupMembersCommand : Command<usergroup>
    {
        public int GroupId { get; set; }

        public override usergroup Build(usergroup usergroup = null, Action<usergroup> additionalAction = null)
        {
            Action<usergroup> action = x =>
            {
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
