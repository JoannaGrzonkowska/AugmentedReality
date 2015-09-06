using Common;

namespace DataAccess.Repository
{
    public interface INoteRepository : IRepository<notes>
    {
        CommandResult Add(notes note, ref int noteId);
    }
}
