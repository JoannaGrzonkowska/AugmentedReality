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
        	
		[ActionName("RetrieveUsersNotes")]
        [HttpGet]
        public IEnumerable<UserNoteDTO> GetRetriveUsersGroups(int id)
        {
            var notes = ServiceLocator.QueryBus.Retrieve<RetrieveUsersNotesQuery, RetrieveUsersNotesQueryResult>(new RetrieveUsersNotesQuery(id)).Notes;
            return notes;
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

