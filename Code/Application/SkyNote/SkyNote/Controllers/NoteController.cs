using CQRS.Implementation.Commands;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using SkyNote.ViewModels;
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

        [ActionName("NotesByLocation")]
        [HttpGet]
        public IEnumerable<NoteDTO> GetNotesByLocation(decimal? xCord, decimal? yCord, int radius = 20, int? categoryId = null, int? typeId = null)
        {
            var notes = ServiceLocator.QueryBus.Retrieve<NotesByLocationQuery, NotesByLocationQueryResult>(new NotesByLocationQuery()
            {
                XCord = xCord,
                YCord = yCord,
                Radius = radius,
                CategoryId = categoryId,
                TypeId = typeId
            }).Notes;
            return notes;
        }

        [ActionName("MyNotesViewModel")]
        [HttpGet]
        public MyNotesViewModel GetMyNotesViewModel()
        {
            var myNotesViewModel = new MyNotesViewModel();
            myNotesViewModel.Categories = ServiceLocator.QueryBus.Retrieve<CategoriesForSelectQuery, CategoriesForSelectQueryResult>(new CategoriesForSelectQuery()).Categories;
            myNotesViewModel.Notes = ServiceLocator.QueryBus.Retrieve<NotesByDateQuery, NotesByDateQueryResult>(new NotesByDateQuery()).Notes;
            return myNotesViewModel;
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

