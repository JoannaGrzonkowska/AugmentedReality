using CQRS.Commands;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkyNote.Controllers
{
    public class BaseController : ApiController
    {
        public HttpResponseMessage SendCommand<T>(T command) where T : ICommand
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }
    }
}
