using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveUsersNotesQueryHandler : IQueryHandler<RetrieveUsersNotesQuery, RetrieveUsersNotesQueryResult>
    {
        private readonly INoteDenormalizedRepository noteRepository;

        public RetrieveUsersNotesQueryHandler(INoteDenormalizedRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public RetrieveUsersNotesQueryResult Handle(RetrieveUsersNotesQuery handle)
        {
            RetrieveUsersNotesQueryResult result = new RetrieveUsersNotesQueryResult();
            var notes = noteRepository.GetAll().Where(x => x.UserId == handle.UserId && x.Identyfication != null && x.Identyfication.Equals("NOTE")).ToList();

            result.Notes = Mapper.Map<IEnumerable<UserNoteDTO>>(notes);

            return result;
        }
    }
}
