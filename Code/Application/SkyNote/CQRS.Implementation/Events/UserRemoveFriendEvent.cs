using CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Events
{
    public class UserRemoveFriendEvent : Event
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public UserRemoveFriendEvent(int userId, int friendId)
        {
            UserId = userId;
            FriendId = friendId;
        }
    }
}
