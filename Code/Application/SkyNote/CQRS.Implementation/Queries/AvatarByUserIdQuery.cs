using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class AvatarByUserIdQuery : IQuery
    {
        public int UserId { get; set; }
    }
}
