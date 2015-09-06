using AppControl.Models;
using Common;
using System.Web.Http;

namespace AppControl.Controllers
{
    public class UserController : ApiController
    {
        public CommandResult Post(User user)
        {
            var t = user.Firstname;
            return new CommandResult(/*new []{"Error1","Error2"}*/);
        }
    }
}