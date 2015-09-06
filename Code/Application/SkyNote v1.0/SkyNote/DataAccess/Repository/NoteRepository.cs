using Common;
using DataAccess.RepositoryCommands;

namespace DataAccess.Repository
{
    public class NoteRepository : RepositoryBase<notes, kasiaskynoteEntities>, INoteRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public NoteRepository(kasiaskynoteEntities context,
            IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(notes note, ref int noteId)
        {
            Add(note);
            _unitOfWork.SaveChanges();

            noteId = note.Id;

            return new CommandResult();
        }
    }
}
