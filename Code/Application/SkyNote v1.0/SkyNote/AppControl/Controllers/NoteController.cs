using AppControl.Models;
using BusinessLogic.Models;
using BusinessLogic.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppControl.Controllers
{
    //[Authorize]
    public class NoteController : ApiController
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService notesService)
        {
            _noteService = notesService;
        }

        // GET api/values
        public IEnumerable<Note> Get()
        {
            var notes = new List<Note>(){
                new Note{
                    Id=1,
                    Content ="sth 1"
                },
                new Note{
                    Id=2,
                    Content ="sth 2"
                }
            };
            return notes;
        }

        // GET api/values/5
        public Note Get(int id)
        {
            if (id == -1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var note = new Note
            {
                Id = 2,
                Content = "sth 2"
            };

            return note;
        }

        // POST api/values
        public HttpResponseMessage Post(Note note)
        {
            int id = -1;
            _noteService.Add(new NoteModel
            {
                Content = note.Content + "tttest",
                Topic = note.Topic,
                Id = note.Id + 1000
            }, ref id);

            
            var r = Request.CreateResponse<Note>(HttpStatusCode.Created, note);
            return r;
        }

        public HttpResponseMessage Put(Note note)
        {
            var noteAdded = new Note
            {
                Id = note.Id,
                Content = note.Content + " sjfbdjf"
            };

            var r = Request.CreateResponse<Note>(HttpStatusCode.Created, noteAdded);
            return r;
        }

        // DELETE api/values/5
        public Note Delete(int id)
        {
            if (id == -1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var comment = new Note
            {
                Id = 2,
                Content = "sth 2"
            };

            return comment;
        }
    }
}