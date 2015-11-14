using System.Linq;

namespace DataAccess.Repositories.Implementation
{
    public class UsergroupRepository : RepositoryBase<usergroup, skynotedbEntities1>, IUsergroupRepository
    {
        public UsergroupRepository(skynotedbEntities1 context)
            :base(context)
        {
        }

        public IQueryable<usergroup> RetriveUserGroupPairsByUserId(int UserId)
        {
            return Context.Set<usergroup>()
                .Where(x => x.UserId == UserId);
        }

        public IQueryable<usergroup> RetriveUserGroupPairsByGroupId(int GroupId)
        {
            return Context.Set<usergroup>()
                .Where(x => x.GroupId == GroupId);
        }
    }
}
