using CQRS.Commands;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Commands
{
    public class UserRemoveFriendCommand : Command<userfriends>
    {
        public int UserFriendsId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public override userfriends Build(userfriends userfriend = null, Action<userfriends> additionalAction = null)
        {
            Action<userfriends> action = x =>
            {
                x.UserfriendsId = UserFriendsId;
                x.UserId = UserId;
                x.FriendId = FriendId;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(userfriend, action);
        }
    }
}
