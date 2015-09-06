using BusinessLogic.Models;
using Common;
using DataAccess;
using DataAccess.Repository;

namespace BusinessLogic.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public CommandResult Add(NoteModel note,
            ref int noteId)
        {
            var noteAdded = new notes
            {
                Topic = note.Topic,
                Content = note.Content
            };
            return _noteRepository.Add(noteAdded, ref noteId);
        }
    }
}
