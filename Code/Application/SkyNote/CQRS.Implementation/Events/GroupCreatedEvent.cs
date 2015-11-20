using CQRS.Events;

namespace CQRS.Implementation.Events
{
    public class GroupCreatedEvent : Event
    {
        public string GroupName { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserMail { get; set; }

        public GroupCreatedEvent(
            int groupId, string groupName, string role,
            int userId, string userName, string userLogin, string userMail)
        {
            AggregateId = groupId;
            GroupName = groupName;
            Role = role;
            UserName = userName;
            UserLogin = userLogin;
            UserMail = userMail;
            UserId = userId;
        }
    }
}
