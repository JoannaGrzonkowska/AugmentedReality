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
        private readonly IGroupDenormalizedRepository groupRepository;

        public NotesByLocationQueryHandler(INoteDenormalizedRepository noteRepository,
            IGroupDenormalizedRepository groupRepository)
        {
            this.noteRepository = noteRepository;
            this.groupRepository = groupRepository;
        }
                
        public NotesByLocationQueryResult Handle(NotesByLocationQuery handle)
        {
            var result = new NotesByLocationQueryResult();
            result.Notes = noteRepository.NotesInLocationRange(handle.UserId, handle.XCord, handle.YCord, handle.Radius, handle.CategoryId, handle.TypeId, handle.GroupIds).Select(x => NoteDTO.Build(x));
            return result;
        }
    }
}
