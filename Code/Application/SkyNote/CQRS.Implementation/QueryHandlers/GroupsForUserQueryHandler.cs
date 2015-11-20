using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class GroupsForUserQueryHandler : IQueryHandler<GroupsForUserQuery, GroupsForUserQueryResult>
    {
        private readonly IGroupDenormalizedRepository groupRepository;

        public GroupsForUserQueryHandler(IGroupDenormalizedRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public GroupsForUserQueryResult Handle(GroupsForUserQuery handle)
        {
            GroupsForUserQueryResult result = new GroupsForUserQueryResult();
            var groups = groupRepository.GetAllQueryable().Where(x => x.UserId == handle.UserId).ToList();
            
            result.GroupsDTO = Mapper.Map<IEnumerable<GroupDTO>>(groups);
            
            return result;
        }
    }
}
