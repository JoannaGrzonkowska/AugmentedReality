using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetriveGroupMembersQueryHandler : IQueryHandler<RetriveGroupMembersQuery, RetriveGroupMembersQueryResult>
    {
        private readonly IGroupDenormalizedRepository groupRepository;

        public RetriveGroupMembersQueryHandler(IGroupDenormalizedRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public RetriveGroupMembersQueryResult Handle(RetriveGroupMembersQuery handle)
        {
            RetriveGroupMembersQueryResult result = new RetriveGroupMembersQueryResult();
            var groups = groupRepository.GetAll().Where(x => x.GroupId == handle.GroupId).ToList();

            result.Users = Mapper.Map<IEnumerable<GroupMemberDTO>>(groups);

            return result;
        }
    }
}
