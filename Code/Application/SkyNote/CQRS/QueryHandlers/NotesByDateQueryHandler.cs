using System;
using CQRS.Queries;
using DataAccessDenormalized.Repository;
using System.Linq;

namespace CQRS.QueryHandlers
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
