using BusinessLogic.Models;
using Common;

namespace BusinessLogic.Services
{
    public interface INoteService
    {
        CommandResult Add(NoteModel note, ref int noteId);
    }
}
