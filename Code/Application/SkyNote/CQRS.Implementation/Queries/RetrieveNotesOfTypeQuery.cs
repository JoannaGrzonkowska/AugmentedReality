using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class RetrieveNotesOfTypeQuery : IQuery
    {
        public int TypeId { get; set; }

        public RetrieveNotesOfTypeQuery(int id)
        {
            TypeId = id;
        }
    }
}
