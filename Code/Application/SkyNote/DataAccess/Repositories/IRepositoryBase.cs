using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public interface IRepositoryBase<TModel>
      where TModel : class
    {
        void Add(TModel entity);
        void Delete(TModel entity);
        IEnumerable<TModel> GetAll();
        IQueryable<TModel> GetAllQueryable();
        TModel GetById(int id);
        void SaveChanges();
    }
}
