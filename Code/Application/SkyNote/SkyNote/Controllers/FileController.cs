using CQRS.Implementation.Queries;
using CQRS.Implementation.Static;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SkyNote.Controllers
{
    public class FileController : ApiController
    {
        private string filesDirPath = HttpContext.Current.Server.MapPath("~/App_Data");

        [ActionName("GetUserAvatar")]
        [HttpGet]
        public HttpResponseMessage GetUserAvatar(int userId)
        {
            var filename = ServiceLocator.QueryBus.Retrieve<AvatarByUserIdQuery, AvatarByUserIdQueryResult>( new AvatarByUserIdQuery() { UserId = userId }).AvatarFileName;
            return GetFile(StaticData.UserAvatarsDirectory, filename);
        }

        [ActionName("GetNoteImage")]
        [HttpGet]
        public HttpResponseMessage GetNoteImage(int noteId, string filename)
        {
           return GetFile(Path.Combine(StaticData.NotesDirectory, noteId.ToString()), filename);
        }

        private HttpResponseMessage GetFile(string dir, string filename)
        {
            try
            {
                var filePath = Path.Combine(filesDirPath, dir, filename);
                var stream = new FileStream(filePath, FileMode.Open);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
