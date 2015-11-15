using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories.Implementation
{
    public class UserRepository : RepositoryBase<user, skynotedbEntities1>, IUserRepository
    {
        public UserRepository(skynotedbEntities1 context)
            :base(context)
        {
        }

        public IQueryable<user> RetriveUsersByIds(List<int> UserIdList)
        {
            return Context.Set<user>()
                .Where(x => UserIdList.Contains(x.UserID));
        }

        public IQueryable<user> RetriveUserById(int UserId)
        {
            return Context.Set<user>()
                .Where(x => x.UserID == UserId);
        }
    }
}
