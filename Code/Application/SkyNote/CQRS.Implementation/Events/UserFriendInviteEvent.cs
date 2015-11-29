using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class UserFriendInviteEvent: Event
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserMail { get; set; }
        public int FriendId { get; set; }
        public string FriendName { get; set; }
        public string FriendLogin { get; set; }
        public string FriendMail { get; set; }
        public string State { get; set; }

        public UserFriendInviteEvent(
            int userId, string userName, string userLogin, string userMail,
            int friendId, string friendName, string friendLogin, string friendMail
            )
        {
            UserId = userId;
            UserName = userName;
            UserLogin = userLogin;
            UserMail = userMail;
            FriendId = friendId;
            FriendName = friendName;
            FriendLogin = friendLogin;
            FriendMail = friendMail;
            State = "PENDING";
        }

    }
}
