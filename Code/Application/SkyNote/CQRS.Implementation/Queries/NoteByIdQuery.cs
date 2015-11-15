using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class NoteByIdQuery : IQuery
    {
        public int NoteId { get; set; }

        public NoteByIdQuery(int noteId)
        {
            NoteId = noteId;
        }
    }
}
