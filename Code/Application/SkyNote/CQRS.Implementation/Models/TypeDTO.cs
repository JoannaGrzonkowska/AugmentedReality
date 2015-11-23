using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Models
{
    public class TypeDTO
    {
        public int? TypeId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
    }
}
