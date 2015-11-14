using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories.Implementation
{
    public class GroupRepository : RepositoryBase<group, skynotedbEntities1>, IGroupRepository
    {
        public GroupRepository(skynotedbEntities1 context)
            : base(context)
        {
        }
            public IQueryable<group> RetriveGroupsByIds(List<int> GroupIdList)
            {
                return Context.Set<group>()
                    .Where(x => GroupIdList.Contains(x.Id));            
            }
    }
}
