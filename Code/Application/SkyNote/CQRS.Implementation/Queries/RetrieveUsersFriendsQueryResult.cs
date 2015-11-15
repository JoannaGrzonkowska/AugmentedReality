using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class RetrieveUsersFriendsQueryResult : IQueryResult
    {
        public IEnumerable<FriendDTO> Friends { get; set; }
    }
}
