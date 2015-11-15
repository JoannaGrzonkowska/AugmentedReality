using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetrieveUsersNotesQuery : IQuery
    {
        public int UserId { get; set; }

        public RetrieveUsersNotesQuery(int userId)
        {
            UserId = userId;
        }
    }
}
