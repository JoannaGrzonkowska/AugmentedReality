using CQRS.Commands;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Commands
{
    public class RetrieveUsersFriendsCommand : Command<userfriends>
    {
        public int USerId { get; set; }

        public override userfriends Build(userfriends userfriends = null, Action<userfriends> additionalAction = null)
        {
            Action<userfriends> action = x =>
            {
                x.UserId = USerId;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(userfriends, action);
        }
    }
}
