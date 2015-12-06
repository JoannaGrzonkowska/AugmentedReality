using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetrieveUsersFriendsQuery : IQuery
    {
        public int UserId { get; set; }

        public RetrieveUsersFriendsQuery(int userId)
        {
            UserId = userId;
        }
    }
}
