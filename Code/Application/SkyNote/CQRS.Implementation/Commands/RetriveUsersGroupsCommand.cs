using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class RetriveUsersGroupsCommand : Command<usergroup>
    {
        public int UserId { get; set; }

        public override usergroup Build(usergroup usergroup = null, Action<usergroup> additionalAction = null)
        {
            Action<usergroup> action = x =>
            {
                x.UserId = UserId;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(usergroup, action);
        }
    }
}
