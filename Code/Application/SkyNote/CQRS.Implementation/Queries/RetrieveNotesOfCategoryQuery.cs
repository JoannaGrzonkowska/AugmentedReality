using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetrieveNotesOfCategoryQuery : IQuery
    {
        public int CategoryId { get; set; }

        public RetrieveNotesOfCategoryQuery(int id)
        {
            CategoryId = id;
        }
    }
}
