using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class RetriveGroupMembersQueryResult : IQueryResult
    {
        public IEnumerable<GroupMemberDTO> Users { get; set; }
    }
}
