namespace CQRS.Implementation.Models
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }
}
