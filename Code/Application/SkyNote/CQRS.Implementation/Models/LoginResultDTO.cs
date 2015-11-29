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
        public bool IsSignedIn { get; set; }
        public string ErrorMessage { get; set; }

        public LoginResultDTO(int UserId, string UserName)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            IsSignedIn = true;
            ErrorMessage = "";
        }
        public LoginResultDTO(string ErrorMessage)
        {
            UserId = -1;
            UserName = "";
            IsSignedIn = false;
            this.ErrorMessage = ErrorMessage;
        }
    }
}
