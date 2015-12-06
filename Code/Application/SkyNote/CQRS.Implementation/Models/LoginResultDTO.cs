using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Models
{
    public class LoginResultDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserFriendGroupId { get; set; }
        public bool IsSignedIn { get; set; }
        public string ErrorMessage { get; set; }

        public LoginResultDTO(int UserId, string UserName, int UserFriendGroupId)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.UserFriendGroupId = UserFriendGroupId;
            IsSignedIn = true;
            ErrorMessage = "";
        }
        public LoginResultDTO(string ErrorMessage)
        {
            UserId = -1;
            UserName = "";
            UserFriendGroupId = -1;
            IsSignedIn = false;
            this.ErrorMessage = ErrorMessage;
        }
    }
}
