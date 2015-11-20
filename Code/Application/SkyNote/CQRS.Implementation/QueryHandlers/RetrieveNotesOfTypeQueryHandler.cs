using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveNotesOfTypeQueryHandler : IQueryHandler<RetrieveNotesOfTypeQuery, RetrieveNotesOfTypeQueryResult>
    {
        private readonly INoteDenormalizedRepository _noteRepository;

        public RetrieveNotesOfTypeQueryHandler(INoteDenormalizedRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public RetrieveNotesOfTypeQueryResult Handle(RetrieveNotesOfTypeQuery handle)
        {
            var result = new RetrieveNotesOfTypeQueryResult();
            var notes = _noteRepository.GetAllQueryable().Where(x => x.TypeId == handle.TypeId);
            result.Notes = Mapper.Map<IEnumerable<NoteDTO>>(notes);
            return result;
        }
    }
}
