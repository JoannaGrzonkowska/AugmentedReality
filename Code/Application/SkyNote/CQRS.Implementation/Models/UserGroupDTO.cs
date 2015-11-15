namespace CQRS.Implementation.Models
{
    public class UserGroupDTO
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; }
    }
}
