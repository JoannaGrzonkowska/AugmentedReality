using CQRS.Implementation.Commands;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SkyNote.Controllers
{
    public class FileController : ApiController
    {
        // GET: api/Group
        public IEnumerable<GroupDTO> Get()
        {
            var groups = ServiceLocator.QueryBus.Retrieve<GroupsForUserQuery, GroupsForUserQueryResult>
                (new GroupsForUserQuery(1)).GroupsDTO;
            return groups;
        }

        [ActionName("File")]
        [HttpGet]
        public HttpResponseMessage File()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var destinationDirPath = HttpContext.Current.Server.MapPath("~/App_Data/Avatars");


            var filename = "asia.jpg";
            var serverPath = Path.Combine(destinationDirPath, filename);

            var stream = new FileStream(serverPath, System.IO.FileMode.Open);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return response;
        }
    }
}
