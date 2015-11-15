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
        // GET api/values
        public IEnumerable<DataAccessDenormalized.note> Get()
        {   
            var notes = ServiceLocator.QueryBus.Retrieve<NotesByDateQuery, NotesByDateQueryResult>(new NotesByDateQuery()).Notes;
            return notes;
        }

        // GET api/values/5
        [ActionName("RetrieveUsersNotes")]
        [HttpGet]
        public IEnumerable<UserNoteDTO> GetRetriveUsersGroups(RetrieveUsersNotesCommand command)
        {
            //TODO - RETRIVE COMMAND FROM AJAX CORRECTLY
            var notes = ServiceLocator.QueryBus.Retrieve<RetrieveUsersNotesQuery, RetrieveUsersNotesQueryResult>(new RetrieveUsersNotesQuery(1)).Notes;
            return notes;
        }

        // GET api/values/5
        //public DataAccessDenormalized.note Get(int id)
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


        [ActionName("AddNewNote")]
        [HttpPost]
        public HttpResponseMessage Post(CreateNoteCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        // POST api/values
       /* public HttpResponseMessage Post(DataAccess.note note)
        {
            //ServiceLocator.CommandBus.Send(new CreateNoteCommand(1, 1, "kasia asia", "Szymon", 1));

            var r = Request.CreateResponse(HttpStatusCode.Created);
            return r;
        }*/

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

