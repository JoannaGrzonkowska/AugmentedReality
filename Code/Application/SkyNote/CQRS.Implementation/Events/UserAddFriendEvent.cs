using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class UserAddFriendEvent : Event
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserMail { get; set; }
        public int FriendId { get; set; }
        public string FriendName { get; set; }
        public string FriendLogin { get; set; }
        public string FriendMail { get; set; }

        public UserAddFriendEvent(
            int userId, string userName, string userLogin, string userMail,
            int friendId, string friendName, string friendLogin, string friendMail
            )
        {
            this.UserId = userId;
            this.UserName = userName;
            this.UserLogin = userLogin;
            this.UserMail = userMail;
            this.FriendId = friendId;
            this.FriendName = friendName;
            this.FriendLogin = friendLogin;
            this.FriendMail = friendMail;
        }
    }
}
