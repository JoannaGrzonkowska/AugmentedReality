namespace CQRS.Implementation.Models
{
    public class GroupInviteDTO
    {
        public int Id { get; set; }

        // User that sended invite
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserMail { get; set; }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
