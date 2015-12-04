using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetrieveFriendInvitesQuery : IQuery
    {
        public int InvitedUserId { get; set; }

        public RetrieveFriendInvitesQuery(int userId)
        {
            InvitedUserId = userId;
        }
    }
}
