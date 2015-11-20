using System.Linq;

namespace DataAccess.Repositories.Implementation
{
    public class TypeRepository : RepositoryBase<types, skynotedbEntities1>, ITypeRepository
    {
        public TypeRepository(skynotedbEntities1 context)
            :base(context)
        {

        }

        public types GetById(int id)
        {
            return Context.Set<types>()
                .FirstOrDefault(x => x.TypeId == id);
        }
    }
}
