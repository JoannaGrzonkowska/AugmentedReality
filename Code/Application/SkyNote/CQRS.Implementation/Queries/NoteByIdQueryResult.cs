using CQRS.Implementation.Models;
using CQRS.Queries;
using DataAccessDenormalized;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class NoteByIdQueryResult : IQueryResult
    {
        public NoteDTO Note { get; set; }
    }
}
