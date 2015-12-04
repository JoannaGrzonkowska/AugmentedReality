using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetrieveGroupInvitesQuery : IQuery
    {
        public int InvitedUserId { get; set; }

        public RetrieveGroupInvitesQuery(int userId)
        {
            InvitedUserId = userId;
        }
    }
}
