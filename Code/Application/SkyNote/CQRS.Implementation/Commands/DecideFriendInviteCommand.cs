using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class DecideFriendInviteCommand : Command<userfriendsinvites>
    {
        public int InvatedUserId { get; set; }
        public int InvatingUserId { get; set; }
        public string State { get; set; }
        
        public override userfriendsinvites Build(userfriendsinvites userfriendsinvites = null, Action<userfriendsinvites> additionalAction = null)
        {
            Action<userfriendsinvites> action = x =>
            {
                x.UserId = InvatingUserId;
                x.FriendId = InvatedUserId;
                x.State = State;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(userfriendsinvites, action);
        }
    }
}
