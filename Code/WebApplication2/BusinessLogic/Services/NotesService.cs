using BusinessLogic.Models;
using Common;
using DataAccessTest;
using DataAccessTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class NotesService: INotesService
    {
        private readonly INotesRepository _examinationsRepository;

        public NotesService(INotesRepository examinationsRepository)
        {
            _examinationsRepository = examinationsRepository;
        }

        public CommandResult Add(NoteModel examinationMessage,
            ref int examinationId)
        {
            var examination = new note
            {
               //idNote = examinationMessage.Id,
               content = examinationMessage.Content
            };
            return _examinationsRepository.Add(examination, ref examinationId);
        }
    }
}
