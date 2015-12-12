using CQRS.Commands;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace SkyNote.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [ActionName("RetriveUsersGroups")]
        [HttpGet]
        public IEnumerable<UserGroupDTO> GetRetriveUsersGroups(int id)
        {
            var groups = ServiceLocator.QueryBus.Retrieve<RetriveUsersGroupsQuery, RetriveUsersGroupsQueryResult>(new RetriveUsersGroupsQuery(id)).Groups;
            return groups;
        }

        [ActionName("RetrieveUsersFriends")]
        [HttpGet]
        public IEnumerable<FriendDTO> GetRetrieveUsersFriends(int id)
        {
            var friends = ServiceLocator.QueryBus.Retrieve<RetrieveUsersFriendsQuery, RetrieveUsersFriendsQueryResult>(new RetrieveUsersFriendsQuery(id)).Friends;
            return friends;
        }

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

        [ActionName("InviteFriend")]
        [HttpPost]
        public HttpResponseMessage PostInviteFriend(UserInviteFriendCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        [ActionName("GetFriendInvites")]
        [HttpGet]
        public IEnumerable<FriendInviteDTO> GetRetrieveFriendInvites(int id)
        {
            var friendsInvites = ServiceLocator.QueryBus.Retrieve<RetrieveFriendInvitesQuery, RetrieveFriendInvitesQueryResult>(new RetrieveFriendInvitesQuery(id)).FriendInvites;
            return friendsInvites;
        }

        [ActionName("DecideFriendInvite")]
        [HttpPost]
        public HttpResponseMessage DecideFriendInvite(DecideFriendInviteCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        [ActionName("InviteToGroup")]
        [HttpPost]
        public HttpResponseMessage PostInviteToGroup(InviteToGroupCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }

        [ActionName("GetGroupInvites")]
        [HttpGet]
        public IEnumerable<GroupInviteDTO> GetRetrieveGroupInvites(int id)
        {
            var groupInvites = ServiceLocator.QueryBus.Retrieve<RetrieveGroupInvitesQuery, RetrieveGroupInvitesQueryResult>(new RetrieveGroupInvitesQuery(id)).GroupInvates;
            return groupInvites;
        }

        [ActionName("GetUserById")]
        [HttpGet]
        public UserDTO GetUserById(int id)
        {
            var user = ServiceLocator.QueryBus.Retrieve<GetUserByIdQuery, GetUserByIdQueryResult>(new GetUserByIdQuery {UserId=id }).User;
            return user;
        }

        [ActionName("DecideGroupInvite")]
        [HttpPost]
        public HttpResponseMessage DecideGroupInvite(DecideGroupInviteCommand command)
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

        [ActionName("RemoveFriend")]
        [HttpPost]
        public HttpResponseMessage PostRemoveFriend(UserRemoveFriendCommand command)
        {
            var result = ServiceLocator.CommandBus.Send(command);
            return Request.CreateResponse(result.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result);
        }
        
        [ActionName("SignIn")]
        [HttpPost]
        [AllowAnonymous]
        public LoginResultDTO Login(LoginCommand command)
        {
            var loginResult = ServiceLocator.QueryBus.Retrieve<UserLoginQuery, UserLoginQueryResult>(new UserLoginQuery(command.Login, command.Password)).loginResult;
            return loginResult;
        }

        [ActionName("GetAllPotentialFriends")]
        [HttpGet]
        public IEnumerable<PotentialFriendDTO> GetAllPotentialFriends(int id)
        {
            var Users = ServiceLocator.QueryBus.Retrieve<GetAllPotentialFriendsQuery, GetAllPotentialFriendsQueryResult>(new GetAllPotentialFriendsQuery(id)).Users;
            return Users;
        }

        [HttpPost]
        public CommandResult UpdateAvatar(UpdateUserAvatarCommand command)
        {
            ImageData imageData = ImageHelper.GetBase64ImageDataFromCropboxLib(command.ImageBase64);
           
            command.DestinationDirPath = HttpContext.Current.Server.MapPath("~/App_Data/Avatars");
            command.ImageBytes = imageData.Bytes;

            var result = ServiceLocator.CommandBus.Send(command);
            return new CommandResult();
        }

        [ActionName("GetPotentialGroupMembers")]
        [HttpGet]
        public IEnumerable<FriendDTO> GetPotentialGroupMembers(int userId, int groupId)
        {
            var potentialMembers = ServiceLocator
                .QueryBus.Retrieve<GetPotentialGroupMembersQuery, GetPotentialGroupMembersQueryResult>
                (new GetPotentialGroupMembersQuery(userId, groupId)).Friends;
            return potentialMembers;
        }
   }

    public class ImageData
    {
        public string ImageType { get; set; }
        public byte[] Bytes { get; set; }
    }

    public class ImageHelper
    {
        public static ImageData GetBase64ImageDataFromImg(string imageBase64)
        {
            var match = Regex.Match(imageBase64, @"\""data:image/(.*?);base64,(.*?)\""", RegexOptions.IgnoreCase);
            return GetBase64ImageData(match);
        }

        public static ImageData GetBase64ImageDataFromCropboxLib(string imageBase64)
        {
            var match = Regex.Match(imageBase64, @"data:image/(.*?);base64,(.*)", RegexOptions.IgnoreCase);
            return GetBase64ImageData(match);
        }

        private static ImageData GetBase64ImageData(Match match)
        {
            var imageType = match.Groups[1].Value;
            var base64 = match.Groups[2].Value;

            var bytes = Convert.FromBase64String(base64.Trim('\0'));

            return new ImageData
            {
                ImageType = imageType,
                Bytes = bytes
            };
        }
    }
}
