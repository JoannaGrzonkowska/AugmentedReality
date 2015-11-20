using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class UserJoinGroupEvent : Event
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; }

        public string GroupName { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserMail { get; set; }

        public UserJoinGroupEvent(
            int userId, int groupId, string role,
            string groupName, string userName, string userLogin, string userMail)
        {
            this.UserId = userId;
            this.GroupId = groupId;
            this.Role = role;
            this.GroupName = groupName;
            this.UserName = userName;
            this.UserLogin = userLogin;
            this.UserMail = userMail;
        }
    }
}
