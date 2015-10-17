using DataAccessDenormalized;
using System.Collections.Generic;

namespace CQRS.Queries
{
    public class NotesByDateQueryResult : IQueryResult
    {
        public IEnumerable<note> Notes { get; set; }
    }
}
