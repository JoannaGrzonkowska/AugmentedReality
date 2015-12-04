using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Queries
{
    public class UserLoginQuery : IQuery
    {
        public string Password { get; set; }
        public string Login { get; set; }

        public UserLoginQuery(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
    }
}
