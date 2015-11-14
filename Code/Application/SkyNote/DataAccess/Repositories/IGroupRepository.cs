using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public interface IGroupRepository : IRepositoryBase<group>
    {
        IQueryable<group> RetriveGroupsByIds(List<int> GroupIdList);
    }
}
