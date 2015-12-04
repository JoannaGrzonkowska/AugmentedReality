using CQRS.Commands;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Commands
{
    public class DecideGroupInviteCommand : Command<usergroupinvites>
    {
        public int InvatedUserId { get; set; }
        public int InvatingUserId { get; set; }
        public int GroupId { get; set; }
        public string State { get; set; }

        public override usergroupinvites Build(usergroupinvites usergroupinvites = null, Action<usergroupinvites> additionalAction = null)
        {
            Action<usergroupinvites> action = x =>
            {
                x.UserId = InvatingUserId;
                x.InvatedId = InvatedUserId;
                x.GroupId = GroupId;
                x.State = State;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(usergroupinvites, action);
        }
    }
}
