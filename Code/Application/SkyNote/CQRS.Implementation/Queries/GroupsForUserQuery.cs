using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class GroupsForUserQuery : IQuery
    {
        public int UserId { get; set; }

        public GroupsForUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}
