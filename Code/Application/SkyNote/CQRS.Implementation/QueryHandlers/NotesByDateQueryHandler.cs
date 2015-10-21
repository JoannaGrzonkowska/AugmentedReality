using System;
using CQRS.Queries;
using DataAccessDenormalized.Repository;
using System.Linq;
using CQRS.QueryHandlers;
using CQRS.Implementation.Queries;

namespace CQRS.Implementation.QueryHandlers
{
    public class NotesByDateQueryHandler : IQueryHandler<NotesByDateQuery, NotesByDateQueryResult>
    {
        private readonly INoteDenormalizedRepository noteRepository;

        public NotesByDateQueryHandler(INoteDenormalizedRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }
                
        public NotesByDateQueryResult Handle(NotesByDateQuery handle)
        {
            NotesByDateQueryResult result = new NotesByDateQueryResult();
            result.Notes = noteRepository.GetAll().OrderBy(x => x.Date).ToList();
            return result;
        }
    }
}
