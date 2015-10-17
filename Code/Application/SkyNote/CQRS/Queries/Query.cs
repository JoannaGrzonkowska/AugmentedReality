namespace CQRS.Queries
{
    public class Query
    {
        public int AggregateId { get; set; }
        public int Id
        {
            get; private set;
        }

        public Query(int id)
        {
            Id = id;
        }
    }
}
