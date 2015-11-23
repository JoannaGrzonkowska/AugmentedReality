using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveGroupsNotesQueryHandler : IQueryHandler<RetrieveGroupsNotesQuery, RetrieveGroupsNotesQueryResult>
    {
        private readonly INoteDenormalizedRepository _noteRepository;

        public RetrieveGroupsNotesQueryHandler(INoteDenormalizedRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public RetrieveGroupsNotesQueryResult Handle(RetrieveGroupsNotesQuery handle)
        {
            var result = new RetrieveGroupsNotesQueryResult();
            var notes = _noteRepository.GetAllQueryable().Where(x => x.GroupId == handle.GroupId 
                                                                && x.Identyfication == "NOTE_SHARED_IN_GROUP");

            result.Notes = Mapper.Map<IEnumerable<NoteDTO>>(notes);

            return result;
        }
    }
}
