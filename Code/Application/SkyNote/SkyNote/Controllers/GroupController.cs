using CQRS.Implementation.Commands;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;
using DataAccessDenormalized.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [ActionName("RetriveGroupMembers")]
        [HttpGet]
        public IEnumerable<GroupMemberDTO> GetRetriveGroupMembers(RetriveGroupMembersCommand command)
        {
            var members = ServiceLocator.QueryBus.Retrieve<RetriveGroupMembersQuery, RetriveGroupMembersQueryResult>(new RetriveGroupMembersQuery(1)).Users;
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
        public void Delete(int id)
        {
        }
    }
}
