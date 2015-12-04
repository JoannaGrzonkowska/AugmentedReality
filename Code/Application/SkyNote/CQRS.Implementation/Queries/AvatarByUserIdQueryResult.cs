using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class AvatarByUserIdQueryResult : IQueryResult
    {
        public string AvatarFileName { get; set; }
    }
}
