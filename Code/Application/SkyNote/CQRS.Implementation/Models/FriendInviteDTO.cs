namespace CQRS.Implementation.Models
{
    public class FriendInviteDTO
    {
        public int Id { get; set; }

        // User that sended invite
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserMail { get; set; }
    }
}
