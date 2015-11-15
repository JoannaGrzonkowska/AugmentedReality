using CQRS.Commands;
using DataAccess;

namespace CQRS.Implementation.Commands
{
    public class DeleteNoteCommand : Command<note>
    {
        public int NoteId { get; set; }
    }
}
