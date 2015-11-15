﻿using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class RetrieveUsersNotesQueryResult : IQueryResult
    {
        public IEnumerable<UserNoteDTO> Notes { get; set; }
    }
}