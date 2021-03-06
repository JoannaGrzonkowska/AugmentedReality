﻿using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class GetAllPotentialFriendsQueryResult : IQueryResult
    {
        public IEnumerable<PotentialFriendDTO> Users { get; set; }
    }
}
