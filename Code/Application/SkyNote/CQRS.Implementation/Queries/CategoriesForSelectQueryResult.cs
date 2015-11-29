using CQRS.Implementation.Models;
using CQRS.Queries;
using System.Collections.Generic;

namespace CQRS.Implementation.Queries
{
    public class CategoriesForSelectQueryResult : IQueryResult
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
