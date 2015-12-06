using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class NotesByLocationQueryHandler : IQueryHandler<NotesByLocationQuery, NotesByLocationQueryResult>
    {
        private readonly INoteDenormalizedRepository noteRepository;

        public NotesByLocationQueryHandler(INoteDenormalizedRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }
                
        public NotesByLocationQueryResult Handle(NotesByLocationQuery handle)
        {
            var result = new NotesByLocationQueryResult();
            //result.Notes = noteRepository.NotesInLocationRange(handle.XCord, handle.YCord, handle.Radius, handle.CategoryId, handle.TypeId, handle.GroupIds).Select(x => NoteDTO.Build(x));
            return result;
        }
    }
}
