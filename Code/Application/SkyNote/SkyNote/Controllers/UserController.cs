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
        public IEnumerable<UserGroupDTO> GetRetriveUsersGroups(int id)
        {
            var groups = ServiceLocator.QueryBus.Retrieve<RetriveUsersGroupsQuery, RetriveUsersGroupsQueryResult>(new RetriveUsersGroupsQuery(id)).Groups;
            return groups;
        }

        // GET api/values/5
        [ActionName("RetrieveUsersFriends")]
        [HttpGet]
        public IEnumerable<FriendDTO> GetRetrieveUsersFriends(int id)
        {
            var friends = ServiceLocator.QueryBus.Retrieve<RetrieveUsersFriendsQuery, RetrieveUsersFriendsQueryResult>(new RetrieveUsersFriendsQuery(id)).Friends;
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

        [ActionName("RemoveFriend")]
        [HttpPost]
        public HttpResponseMessage PostRemoveFriend(UserRemoveFriendCommand command)
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

        [HttpPost]
        public CommandResult UpdateAvatar(UpdateUserAvatarCommand command)
        {
            ImageData imageData;
            try
            {
                imageData = ImageHelper.GetBase64ImageDataFromCropboxLib(command.ImageBase64);
            }
            catch (System.ArgumentNullException ex)
            {
                return new CommandResult(new[] { "Base 64 string is null." });
            }
            catch (System.FormatException ex)
            {
                return new CommandResult(new[] { "Base 64 string length is not 4 or is not an even multiple of 4." });
            }

            command.DestinationDirPath = HttpContext.Current.Server.MapPath("~/App_Data/Avatars");
                command.ImageBytes = imageData.Bytes;
                command.ImageExtension = imageData.ImageType;

            var result = ServiceLocator.CommandBus.Send(command);
     
            return new CommandResult();
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
