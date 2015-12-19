using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetriveUsersGroupsQueryHandler : IQueryHandler<RetriveUsersGroupsQuery, RetriveUsersGroupsQueryResult>
    {
        private readonly IGroupDenormalizedRepository groupRepository;

        public RetriveUsersGroupsQueryHandler(IGroupDenormalizedRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public RetriveUsersGroupsQueryResult Handle(RetriveUsersGroupsQuery handle)
        {
            RetriveUsersGroupsQueryResult result = new RetriveUsersGroupsQueryResult();
            var friendsGroups = groupRepository.GetAllQueryable().Where(x => x.UserId != null && x.Role == "OWNER" || x.Role == "Owner");
            List<int> friendsGroupsIds = new List<int>();
            foreach (var friendGroup in friendsGroups)
                if (friendGroup.GroupId != null)
                    friendsGroupsIds.Add((int)friendGroup.GroupId);

            var groups = groupRepository.GetAllQueryable().Where(x => x.UserId == handle.UserId
                                                                 && (x.Role == "Member" || x.Role == "Creator"
                                                                 //|| x.Role == "OWNER"// Un-comment this if also list of user's friends must be displaied 
                                                                 )
                                                                 && !(friendsGroupsIds.Contains((int)x.GroupId))//Comment out this line if group of friends that he belongs to shoud be displaied
                                                                 ).ToList();

            result.Groups = Mapper.Map<IEnumerable<UserGroupDTO>>(groups);

            return result;
        }
    }
}
