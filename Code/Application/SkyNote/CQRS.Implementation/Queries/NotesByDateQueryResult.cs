using CQRS.Queries;
using DataAccessDenormalized;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class NotesByDateQueryResult : IQueryResult
    {
        public IEnumerable<note> Notes { get; set; }
    }
}
