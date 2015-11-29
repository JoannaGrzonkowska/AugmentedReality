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
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class CategoriesForSelectQueryHandler : IQueryHandler<CategoriesForSelectQuery, CategoriesForSelectQueryResult>
    {
        private readonly ICategoryRepository _categoryRepostory;

        public CategoriesForSelectQueryHandler(ICategoryRepository categoryRepostory)
        {
            _categoryRepostory = categoryRepostory;
        }

        public CategoriesForSelectQueryResult Handle(CategoriesForSelectQuery handle)
        {
            var result = new CategoriesForSelectQueryResult();
            
            var categoriesList = new List<CategoryDTO>(){
                new CategoryDTO()
            };
            
            var categories = _categoryRepostory.GetAllQueryable().OrderBy(x => x.Name);
            var categoriesMap = Mapper.Map<IEnumerable<CategoryDTO>>(categories).ToList();

            categoriesMap.ForEach(x =>
            {
                x.Types.Insert(0, new TypeDTO());
            });
            
            categoriesList.AddRange(categoriesMap);

            result.Categories = categoriesList;
            return result;
        }
    }
}
