using CQRS.Implementation.Models;
using CQRS.Queries;
using DataAccessDenormalized;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class RetriveUsersGroupsQueryResult : IQueryResult
    {
        public IEnumerable<UserGroupDTO> Groups { get; set; }
    }
}
