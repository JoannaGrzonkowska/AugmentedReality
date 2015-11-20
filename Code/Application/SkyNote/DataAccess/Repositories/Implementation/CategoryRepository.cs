using System.Linq;

namespace DataAccess.Repositories.Implementation
{
    public class CategoryRepository : RepositoryBase<categories, skynotedbEntities1>, ICategoryRepository
    {
        public CategoryRepository(skynotedbEntities1 context)
            :base(context)
        {

        }

        public categories GetById(int id)
        {
            return Context.Set<categories>()
                .FirstOrDefault(x => x.CategoryId == id);
        }
    }
}
