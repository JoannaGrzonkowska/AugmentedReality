using System;
using DataAccess;
using CQRS.Commands;

namespace CQRS.Implementation.Commands
{
    public class InviteToGroupCommand : Command<usergroupinvites>
    {
        public int UsergroupinvitesId { get; set; }
        public int UserId { get; set; }
        public int InvatedId { get; set; }
        public int GroupId { get; set; }
        public string State { get; set; }

        public override usergroupinvites Build(usergroupinvites usergroupinvites = null, Action<usergroupinvites> additionalAction = null)
        {
            Action<usergroupinvites> action = x =>
            {
                x.UsergroupinviteId = UsergroupinvitesId;
                x.InvatedId = InvatedId;
                x.GroupId = GroupId;
                x.UserId = UserId;
                x.State = "PENDING";

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(usergroupinvites, action);
        }
    }
}
