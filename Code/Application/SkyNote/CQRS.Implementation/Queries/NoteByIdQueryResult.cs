using CQRS.Implementation.Models;
using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class NoteByIdQueryResult : IQueryResult
    {
        public NoteDTO Note { get; set; }
    }
}
