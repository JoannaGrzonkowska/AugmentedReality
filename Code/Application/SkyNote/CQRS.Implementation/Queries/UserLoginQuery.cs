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
        public string UserName { get; set; }

        public UserLoginQuery(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
