using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Linq;

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
            result.Notes = noteRepository.GetAllQueryable().OrderByDescending(x => x.Date).ToList().Select(x=>NoteDTO.Build(x));
            return result;
        }
    }
}
