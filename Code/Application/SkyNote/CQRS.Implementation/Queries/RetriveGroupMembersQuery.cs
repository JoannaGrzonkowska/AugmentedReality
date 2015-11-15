using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetriveGroupMembersQuery : IQuery
    {
        public int GroupId { get; set; }

        public RetriveGroupMembersQuery(int groupid)
        {
            this.GroupId = groupid;
        }
    }
}
