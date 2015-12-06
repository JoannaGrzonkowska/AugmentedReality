using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveUsersFriendsQueryHandler : IQueryHandler<RetrieveUsersFriendsQuery, RetrieveUsersFriendsQueryResult>
    {
        private readonly IGroupDenormalizedRepository groupRepository;
        private readonly IUserfriendgroupRepository userfriendgroupRepository;

        public RetrieveUsersFriendsQueryHandler(IGroupDenormalizedRepository groupRepository, IUserfriendgroupRepository userfriendgroupRepository)
        {
            this.groupRepository = groupRepository;
            this.userfriendgroupRepository = userfriendgroupRepository;
        }

        public RetrieveUsersFriendsQueryResult Handle(RetrieveUsersFriendsQuery handle)
        {
            RetrieveUsersFriendsQueryResult result = new RetrieveUsersFriendsQueryResult();
            var userfriendgroupPair = userfriendgroupRepository.GetAllQueryable().FirstOrDefault( x => x.UserId == handle.UserId);

            if (userfriendgroupPair != null) {
                var friends = groupRepository.GetAllQueryable().Where(x => x.GroupId == userfriendgroupPair.GroupId && x.Role == "Member").ToList();
                
                result.Friends = Mapper.Map<IEnumerable<FriendDTO>>(friends);
            }
            return result;
        }
    }
}
