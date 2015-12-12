using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest.Repository
{
    public class NotesRepository: RepositoryBase<note, skynote2Entities>, INotesRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotesRepository(skynote2Entities context,
            IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(note examination, ref int examinationId)
        {
            Add(examination);
            _unitOfWork.SaveChanges();

            examinationId = examination.idnote;

            return new CommandResult();
        }
    }
}
