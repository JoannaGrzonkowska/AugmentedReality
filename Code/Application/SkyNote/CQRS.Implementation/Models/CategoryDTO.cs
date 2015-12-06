using System.Collections.Generic;

namespace CQRS.Implementation.Models
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IList<TypeDTO> Types;
    }
}
