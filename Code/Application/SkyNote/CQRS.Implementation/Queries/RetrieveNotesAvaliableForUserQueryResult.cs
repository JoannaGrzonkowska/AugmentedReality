using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class RetrieveNotesAvaliableForUserQueryResult : IQueryResult
    {
        public IEnumerable<NoteDTO> Notes { get; set; }
    }
}
