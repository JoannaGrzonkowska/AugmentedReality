using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class NoteByIdQueryHandler : IQueryHandler<NoteByIdQuery, NoteByIdQueryResult>
    {
        private readonly INoteDenormalizedRepository noteRepository;

        public NoteByIdQueryHandler(INoteDenormalizedRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public NoteByIdQueryResult Handle(NoteByIdQuery handle)
        {
            var result = new NoteByIdQueryResult();
            result.Note = NoteDTO.Build(noteRepository.GetAllQueryable().FirstOrDefault(x=>x.NoteId == handle.NoteId));
            return result;
        }
    }
}
