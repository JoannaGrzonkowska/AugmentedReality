using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class GroupsForUserQueryResult : IQueryResult
    {
        public IEnumerable<GroupDTO> GroupsDTO { get; set; }
    }
}
