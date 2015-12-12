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
        public IEnumerable<GroupDTO> Get()
        {
            var groups = ServiceLocator.QueryBus.Retrieve<GroupsForUserQuery, GroupsForUserQueryResult>
                (new GroupsForUserQuery(1)).GroupsDTO;
            return groups;
        }

        [ActionName("RetriveGroupMembers")]
        [HttpGet]
        public IEnumerable<GroupMemberDTO> GetRetriveGroupMembers(int id)
        {
            var members = ServiceLocator.QueryBus.Retrieve<RetriveGroupMembersQuery, RetriveGroupMembersQueryResult>(new RetriveGroupMembersQuery(id)).Users;
            return members;
        }

        public string Get1(int id)
        {
            return "value";
        }

        // POST: api/Group
        [ActionName("AddNewGroup")]
        [HttpPost] 
        public HttpResponseMessage PostAddNewGroup(CreateGroupCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }
        

        // PUT: api/Group/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Group/5
        public HttpResponseMessage Delete(int id)
        {
            var result = ServiceLocator.CommandBus.Send(new DeleteGroupCommand() { GroupId = id });
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }
    }
}
