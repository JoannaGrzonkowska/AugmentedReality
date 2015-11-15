using CQRS.Implementation.Commands;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using DataAccessDenormalized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkyNote.Controllers
{
    public class UserController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [ActionName("RetriveUsersGroups")]
        [HttpGet]
        public IEnumerable<UserGroupDTO> GetRetriveUsersGroups(RetriveUsersGroupsCommand command)
        {
            //TODO - RETRIVE COMMAND FROM AJAX CORRECTLY
            var groups = ServiceLocator.QueryBus.Retrieve<RetriveUsersGroupsQuery, RetriveUsersGroupsQueryResult>(new RetriveUsersGroupsQuery(1)).Groups;
            return groups;
        }

        // GET api/values/5
        [ActionName("RetrieveUsersFriends")]
        [HttpGet]
        public IEnumerable<FriendDTO> GetRetrieveUsersFriends(RetrieveUsersFriendsCommand command)
        {
            //TODO - RETRIVE COMMAND FROM AJAX CORRECTLY
            var friends = ServiceLocator.QueryBus.Retrieve<RetrieveUsersFriendsQuery, RetrieveUsersFriendsQueryResult>(new RetrieveUsersFriendsQuery(1)).Friends;
            return friends;
        }

        // POST api/values
        //public void Post([FromBody]string value) { }
        // POST: api/Group
        [ActionName("AddNewUser")]
        [HttpPost]
        public HttpResponseMessage PostAddNewUser(CreateUserCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        [ActionName("JoinGroup")]
        [HttpPost]
        public HttpResponseMessage PostJoinGroup(UserJoinGroupCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        [ActionName("AddFriend")]
        [HttpPost]
        public HttpResponseMessage PostAddFriend(UserAddFriendCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
