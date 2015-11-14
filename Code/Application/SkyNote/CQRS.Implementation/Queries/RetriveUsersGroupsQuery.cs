using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetriveUsersGroupsQuery : IQuery
    {
        public int UserId { get; set; }

        public RetriveUsersGroupsQuery(int userId)
        {
            this.UserId = userId;
        }
    }
}
