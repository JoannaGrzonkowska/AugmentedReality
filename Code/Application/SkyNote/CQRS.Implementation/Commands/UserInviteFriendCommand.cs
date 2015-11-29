using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class UserInviteFriendCommand : Command<userfriendsinvites>
    {
        public int UserfriendsinviteId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string State { get; set; }

        public override userfriendsinvites Build(userfriendsinvites userfriendinvite = null, Action<userfriendsinvites> additionalAction = null)
        {
            Action<userfriendsinvites> action = x =>
            {
                x.UserfriendsinviteId = UserfriendsinviteId;
                x.UserId = UserId;
                x.FriendId = FriendId;
                x.State = "PENDING";

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(userfriendinvite, action);
        }
    }
}
