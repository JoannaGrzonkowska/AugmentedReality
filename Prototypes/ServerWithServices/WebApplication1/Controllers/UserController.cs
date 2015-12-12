using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UserController : ApiController
    {
        public CommandResult Post(WebApplication1.Models.User user)
        {
            var t = user.Firstname;
            return new CommandResult(/*new []{"Error1","Error2"}*/);
        }
    }
}