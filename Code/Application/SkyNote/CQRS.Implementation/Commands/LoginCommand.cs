using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Commands
{
    public class LoginCommand
    {
        public string Password {get; set;}
        public string Login { get; set; }
    }
}
