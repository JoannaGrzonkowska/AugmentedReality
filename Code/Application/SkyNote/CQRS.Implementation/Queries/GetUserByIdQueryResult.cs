using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class GetUserByIdQueryResult : IQueryResult
    {
        public UserDTO User { get; set; }
    }
}
