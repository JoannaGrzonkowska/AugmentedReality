using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace SkyNote.Controllers
{
    public class CategoryController : ApiController
    {
        [ActionName("Categories")]
        [HttpGet]
        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = ServiceLocator.QueryBus.Retrieve<RetrieveAllCategoriesQuery, RetrieveAllCategoriesQueryResult>(new RetrieveAllCategoriesQuery()).Categories;
            return categories;
        }

        [ActionName("CategoriesSelectList")]
        [HttpGet]
        public IEnumerable<CategoryDTO> GetCategoriesSelectList()
        {
            var categories = ServiceLocator.QueryBus.Retrieve<CategoriesForSelectQuery, CategoriesForSelectQueryResult>(new CategoriesForSelectQuery()).Categories.ToList();
            return categories;
        }
    }
}
