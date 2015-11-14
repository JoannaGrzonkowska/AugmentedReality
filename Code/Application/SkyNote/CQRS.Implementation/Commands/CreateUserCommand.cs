using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class CreateUserCommand : Command<user>
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

        public override user Build(user user = null, Action<user> additionalAction = null)
        {
            Action<user> action = x =>
            {
                x.UserID = UserID;
                x.Name = Name;
                x.Login = Login;
                x.Mail = Mail;
                x.Password = Password;
                x.PasswordSalt = PasswordSalt;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(user, action);
        }
    }
}
