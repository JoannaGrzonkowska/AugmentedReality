using CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Events
{
    public class UserGroupInviteEvent : Event
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserMail { get; set; }
        public int FriendId { get; set; }
        public string FriendName { get; set; }
        public string FriendLogin { get; set; }
        public string FriendMail { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string State { get; set; }

        public UserGroupInviteEvent(
            int userId, string userName, string userLogin, string userMail,
            int friendId, string friendName, string friendLogin, string friendMail,
            int groupId, string groupName)
        {
            UserId = userId;
            UserName = userName;
            UserLogin = userLogin;
            UserMail = userMail;
            FriendId = friendId;
            FriendName = friendName;
            FriendLogin = friendLogin;
            FriendMail = friendMail;
            GroupId = groupId;
            GroupName = groupName;
            State = "PENDING";
        }
    }
}
