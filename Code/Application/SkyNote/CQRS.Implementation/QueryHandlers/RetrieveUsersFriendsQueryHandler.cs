using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveUsersFriendsQueryHandler : IQueryHandler<RetrieveUsersFriendsQuery, RetrieveUsersFriendsQueryResult>
    {
        private readonly IGroupDenormalizedRepository groupRepository;

        public RetrieveUsersFriendsQueryHandler(IGroupDenormalizedRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public RetrieveUsersFriendsQueryResult Handle(RetrieveUsersFriendsQuery handle)
        {
            RetrieveUsersFriendsQueryResult result = new RetrieveUsersFriendsQueryResult();
            var friends = groupRepository.GetAll().Where(x => x.UserId == handle.UserId && x.FriendId != null).ToList(); //CHANGE ! x.UserId == handle.UserId && x.FriendId != null

            result.Friends = Mapper.Map<IEnumerable<FriendDTO>>(friends);

            return result;
        }
    }
}
