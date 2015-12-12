using BusinessLogic.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface INotesService
    {
        CommandResult Add(NoteModel examinationMessage, ref int examinationId);
    }
}
