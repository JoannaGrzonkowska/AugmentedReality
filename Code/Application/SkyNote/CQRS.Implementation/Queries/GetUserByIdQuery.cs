using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class GetUserByIdQuery : IQuery
    {
        public int UserId { get; set; }
    }
}
