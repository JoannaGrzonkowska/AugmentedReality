using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using AutoMapper;
using CQRS.Implementation.Models;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveAllCategoriesQueryHandler : IQueryHandler<RetrieveAllCategoriesQuery, RetrieveAllCategoriesQueryResult>
    {
        private readonly ICategoryRepository _categoryRepostory;

        public RetrieveAllCategoriesQueryHandler(ICategoryRepository categoryRepostory)
        {
            _categoryRepostory = categoryRepostory;
        }

        public RetrieveAllCategoriesQueryResult Handle(RetrieveAllCategoriesQuery handle)
        {
            var result = new RetrieveAllCategoriesQueryResult();
            var categories = _categoryRepostory.GetAllQueryable().OrderBy(x => x.Name).ToList();

            result.Categories = Mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return result;
        }
    }
}
