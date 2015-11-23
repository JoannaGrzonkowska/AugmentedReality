using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
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
            var groups = groupRepository.GetAllQueryable().Where(x => x.UserId == handle.UserId
                                                                 && (x.Role == "Member" || x.Role == "Creator")
                                                                 ).ToList();
            
            result.Groups = Mapper.Map<IEnumerable<UserGroupDTO>>(groups);

            return result;
        }
    }
}
