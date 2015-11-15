using CQRS.Commands;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using DataAccess;
using DataAccessDenormalized;
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

        //public HttpResponseMessage Put(Comment comment)
        //{
        //    var commentAdded = new Comment
        //    {
        //        Id = comment.Id,
        //        Content = comment.Content + " sjfbdjf"
        //    };

        //    var r = Request.CreateResponse<Comment>(HttpStatusCode.Created, commentAdded);
        //    return r;
        //}

        //// DELETE api/values/5
        //public Comment Delete(int id)
        //{
        //    if (id == -1)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    var comment = new Comment
        //    {
        //        Id = 2,
        //        Content = "sth 2"
        //    };

        //    return comment;
        //}
    }
}

