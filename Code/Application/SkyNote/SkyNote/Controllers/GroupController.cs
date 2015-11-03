using CQRS.Implementation.Commands;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkyNote.Controllers
{
    public class GroupController : ApiController
    {
        // GET: api/Group
        public IEnumerable<GroupDTO> Get()
        {
            var groups = ServiceLocator.QueryBus.Retrieve<GroupsForUserQuery, GroupsForUserQueryResult>
                (new GroupsForUserQuery(1)).GroupsDTO;
            return groups;
        }

        // GET: api/Group/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Group
        public HttpResponseMessage Post(CreateGroupCommand command)
        {            
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        // PUT: api/Group/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
        }
    }
}
