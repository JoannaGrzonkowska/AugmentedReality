using CQRS.Implementation.Commands;
using CQRS.Implementation.Commands.Models;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.Implementation.Static;
using SkyNote.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SkyNote.Controllers
{

    public class NoteController : ApiController
    {
        private string filesDirPath = HttpContext.Current.Server.MapPath("~/App_Data");

        public IEnumerable<NoteDTO> Get()
        {
            var notes = ServiceLocator.QueryBus.Retrieve<NotesByDateQuery, NotesByDateQueryResult>(new NotesByDateQuery()).Notes;
            return notes;
        }

        public NoteDetailsViewModel Get(int id)
        {
            var note = ServiceLocator.QueryBus.Retrieve<NoteByIdQuery, NoteByIdQueryResult>(new NoteByIdQuery(id)).Note;
            note.GetImagesFilenames(filesDirPath);

            var noteDetailsViewModel = new NoteDetailsViewModel();
            noteDetailsViewModel.Note = note;
            noteDetailsViewModel.Categories = ServiceLocator.QueryBus.Retrieve<CategoriesForSelectQuery, CategoriesForSelectQueryResult>(new CategoriesForSelectQuery()).Categories;
           
            return noteDetailsViewModel;
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

        [ActionName("RetrieveNotesAvaliableForUser")]
        [HttpGet]
        public IEnumerable<NoteDTO> GetRetrieveNotesAvaliableForUser(int id)
        {
            var notes = ServiceLocator.QueryBus.Retrieve<RetrieveNotesAvaliableForUserQuery, RetrieveNotesAvaliableForUserQueryResult>(new RetrieveNotesAvaliableForUserQuery(id)).Notes;
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
            if (command.CanBeAuthenticated())
            { 
                  command.DestinationDirPath = Path.Combine(filesDirPath, StaticData.NotesDirectory);
            ConvertNoteImagesToByte(command.Images);

            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);

            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage Put(EditNoteCommand command)
        {
            command.DestinationDirPath = Path.Combine(filesDirPath, StaticData.NotesDirectory);
            ConvertNoteImagesToByte(command.Images);

            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        public HttpResponseMessage Delete(int id)
        {
            var result = ServiceLocator.CommandBus.Send(new DeleteNoteCommand() { NoteId = id });
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        private void ConvertNoteImagesToByte(IList<SaveImageModel> images)
        {
            images.Where(x=>!string.IsNullOrEmpty(x.ImageBase64)).ToList().ForEach(image =>
            {
                var imageData = ImageHelper.GetBase64ImageDataFromCropboxLib(image.ImageBase64);
                image.ImageBytes = imageData.Bytes;
            });

        }
    }
}

