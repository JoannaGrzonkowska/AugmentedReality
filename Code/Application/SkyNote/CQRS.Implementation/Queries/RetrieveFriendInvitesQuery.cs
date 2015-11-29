using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Queries
{
    public class RetrieveFriendInvitesQuery : IQuery
    {
        public int InvitedUserId { get; set; }

        public RetrieveFriendInvitesQuery(int userId)
        {
            InvitedUserId = userId;
        }
    }
}
