using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using System.Collections.Generic;
using System.Web.Http;

namespace SkyNote.Controllers
{
    public class CategoryController : ApiController
    {
        [ActionName("RetrieveAllCategories")]
        [HttpGet]
        public IEnumerable<CategoryDTO> GetRetrieveAllCategories()
        {
            var categories = ServiceLocator.QueryBus.Retrieve<RetrieveAllCategoriesQuery, RetrieveAllCategoriesQueryResult>(new RetrieveAllCategoriesQuery()).Categories;
            return categories;
        }

     /*   [ActionName("RetrieveTypesOfCategoryGiven")]
        [HttpGet]
        public IEnumerable<CategoryDTO> GetRetrieveTypesOfCategory()
        {
            var categories = ServiceLocator.QueryBus.Retrieve<GetRetrieveTypesOfCategoryGivenQuery, GetRetrieveTypesOfCategoryGivenQueryResult>(new GetRetrieveTypesOfCategoryGivenQuery()).Types;
            return categories;
        }*/

    }
}
