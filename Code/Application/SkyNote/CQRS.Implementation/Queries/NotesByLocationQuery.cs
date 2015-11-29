using CQRS.Queries;

namespace CQRS.Implementation.Queries
{
    public class NotesByLocationQuery : IQuery
    {
        public decimal? XCord { get; set; }
        public decimal? YCord { get; set; }
        public int Radius { get; set; }
        public int? CategoryId { get; set; }
        public int? TypeId { get; set; }
    }
}
