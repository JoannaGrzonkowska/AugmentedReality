namespace CQRS.Implementation.Models
{
    public class GroupMemberDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string Role { get; set; }
    }
}
