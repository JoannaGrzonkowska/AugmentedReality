using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class GetPotentialGroupMembersQuery : IQuery
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public GetPotentialGroupMembersQuery(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}
