using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetrieveNotesAvaliableForUserQuery : IQuery
    {
        public int UserId { get; set; }

        public RetrieveNotesAvaliableForUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}
