using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccess.Repositories;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class GetPotentialGroupMembersQueryHandler : IQueryHandler<GetPotentialGroupMembersQuery, GetPotentialGroupMembersQueryResult>
    {
        private readonly IUserfriendgroupRepository userfriendgroupRepository;
        private readonly IUsergroupRepository userGroupRepository;
        private readonly IGroupDenormalizedRepository groupRepository;

        public GetPotentialGroupMembersQueryHandler(
            IUserfriendgroupRepository userFriendRepository,
            IUsergroupRepository userGroupRepository,
            IGroupDenormalizedRepository groupRepository)
        {
            this.userfriendgroupRepository = userFriendRepository;
            this.userGroupRepository = userGroupRepository;
            this.groupRepository = groupRepository;
        }
        public GetPotentialGroupMembersQueryResult Handle(GetPotentialGroupMembersQuery handle)
        {
            var groupUserIds = userGroupRepository.GetAllQueryable()
                .Where(x => x.GroupId == handle.GroupId)
                .Select(r => r.UserId)
                .ToList();

            var userfriendgroupPair = userfriendgroupRepository.GetAllQueryable().FirstOrDefault(x => x.UserId == handle.UserId);


            var friends = groupRepository.GetAllQueryable()
                .Where(x => x.GroupId == userfriendgroupPair.GroupId
                         && x.Role == "Member"
                         && !groupUserIds.Contains((int)x.UserId)).ToList();

            var result = new GetPotentialGroupMembersQueryResult();
            result.Friends = Mapper.Map<IEnumerable<FriendDTO>>(friends);

            return result;
        }
    }
}