using CQRS.Implementation.Commands;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkyNote.Controllers
{

    public class NoteController : ApiController
    {
        public IEnumerable<NoteDTO> Get()
        {
            var notes = ServiceLocator.QueryBus.Retrieve<NotesByDateQuery, NotesByDateQueryResult>(new NotesByDateQuery()).Notes;
            return notes;
        }

        public NoteDTO Get(int id)
        {
            var note = ServiceLocator.QueryBus.Retrieve<NoteByIdQuery, NoteByIdQueryResult>(new NoteByIdQuery(id)).Note;
            return note;
        }

        [ActionName("RetrieveNotesOfGivenType")]
        [HttpGet]
        public IEnumerable<NoteDTO> GetRetrieveNotesOfGivenType(int id)
        {
            var notes = ServiceLocator.QueryBus.Retrieve<RetrieveNotesOfTypeQuery, RetrieveNotesOfTypeQueryResult>(new RetrieveNotesOfTypeQuery(id)).Notes;
            return notes;
        }

        [ActionName("RetrieveNotesOfGivenCategory")]
        [HttpGet]
        public IEnumerable<NoteDTO> GetRetrieveNotesOfGivenCategory(int id)
        {
            var notes = ServiceLocator.QueryBus.Retrieve<RetrieveNotesOfCategoryQuery, RetrieveNotesOfCategoryQueryResult>(new RetrieveNotesOfCategoryQuery(id)).Notes;
            return notes;
        }

        [ActionName("RetrieveUsersNotes")]
        [HttpGet]
        public IEnumerable<NoteDTO> GetRetriveUsersNotes(int id)
        {
            var notes = ServiceLocator.QueryBus.Retrieve<RetrieveUsersNotesQuery, RetrieveUsersNotesQueryResult>(new RetrieveUsersNotesQuery(id)).Notes;
            return notes;
        }

        [ActionName("RetrieveGroupsNotes")]
        [HttpGet]
        public IEnumerable<NoteDTO> RetrieveGroupsNotes(int id)
        {
            var notes = ServiceLocator.QueryBus.Retrieve<RetrieveGroupsNotesQuery, RetrieveGroupsNotesQueryResult>(new RetrieveGroupsNotesQuery(id)).Notes;
            return notes;
        }

        [ActionName("ShareNoteInGroup")]
        [HttpPost]
        public HttpResponseMessage Post(ShareNoteInGroupCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        [ActionName("AddNewNote")]
        [HttpPost]
        public HttpResponseMessage Post(CreateNoteCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        public HttpResponseMessage Put(EditNoteCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        public HttpResponseMessage Delete(int id)
        {
            var result = ServiceLocator.CommandBus.Send(new DeleteNoteCommand() { NoteId = id });
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }
    }
}

