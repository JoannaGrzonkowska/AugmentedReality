using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public interface IUserRepository : IRepositoryBase<user>
    {
        IQueryable<user> RetriveUsersByIds(List<int> UserIdList);
    }
}
