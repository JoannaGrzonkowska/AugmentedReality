using BusinessLogic.Services;
using DataAccessTest;
using DataAccessTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    //[Authorize]
    public class CommentsController : ApiController
    {
        private readonly INotesService _notesService;

        public CommentsController(INotesService notesService)
        {
            _notesService = notesService;
        }

        // GET api/values
        public IEnumerable<Comment> Get()
        {
            var comments = new List<Comment>(){
                new Comment{
                    Id=1,
                    Content ="sth 1"
                },
                new Comment{
                    Id=2,
                    Content ="sth 2"
                }
            };
            return comments;
        }

        // GET api/values/5
        public Comment Get(int id)
        {
            if (id == -1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var comment = new Comment
            {
                Id = 2,
                Content = "sth 2"
            };

            return comment;
        }

        // POST api/values
        public HttpResponseMessage Post(Comment comment)
        {

            /*var context = new skynoteEntities();

            var unitOfWork = new UnitOfWork(context);
            var examinationsRepository = new NotesRepository(context, unitOfWork);

           var notesService = new NotesService(examinationsRepository);*/

            int id=-1;
            _notesService.Add(new BusinessLogic.Models.NoteModel
            {
                Content = comment.Content+"tttest",
                Id = comment.Id+100
            }, ref id);

            var commentAdded = new Comment
            {
                Id = comment.Id,
                Content = comment.Content
            };

            var r = Request.CreateResponse<Comment>(HttpStatusCode.Created, comment);
            return r;
        }

        public HttpResponseMessage Put(Comment comment)
        {
            var commentAdded = new Comment
            {
                Id = comment.Id,
                Content = comment.Content
            };

            var r = Request.CreateResponse<Comment>(HttpStatusCode.Created, comment);
            return r;
        }

        // DELETE api/values/5
        public Comment Delete(int id)
        {
            if (id == -1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var comment = new Comment
            {
                Id = 2,
                Content = "sth 2"
            };

            return comment;
        }
    }
}
