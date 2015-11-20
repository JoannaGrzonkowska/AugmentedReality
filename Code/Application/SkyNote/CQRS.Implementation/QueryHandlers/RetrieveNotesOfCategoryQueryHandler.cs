using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveNotesOfCategoryQueryHandler : IQueryHandler<RetrieveNotesOfCategoryQuery, RetrieveNotesOfCategoryQueryResult>
    {
        private readonly INoteDenormalizedRepository _noteRepository;

        public RetrieveNotesOfCategoryQueryHandler(INoteDenormalizedRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public RetrieveNotesOfCategoryQueryResult Handle(RetrieveNotesOfCategoryQuery handle)
        {
            var result = new RetrieveNotesOfCategoryQueryResult();
            var notes = _noteRepository.GetAllQueryable().Where(x => x.CategoryId == handle.CategoryId);

            result.Notes = Mapper.Map<IEnumerable<NoteDTO>>(notes);

            return result;
        }
    }
}
