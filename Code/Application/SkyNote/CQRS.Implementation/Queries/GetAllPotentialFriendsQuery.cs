using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Queries
{
    public class GetAllPotentialFriendsQuery : IQuery
    {
        public int UserId { get; set; }

        public GetAllPotentialFriendsQuery(int userId)
        {
            this.UserId = userId;
        }
    }
}
