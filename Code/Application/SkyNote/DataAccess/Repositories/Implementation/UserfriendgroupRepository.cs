using System.Linq;

namespace DataAccess.Repositories.Implementation
{
    public class UserfriendgroupRepository : RepositoryBase<userfriendsgroup, skynotedbEntities1>, IUserfriendgroupRepository
    {
        public UserfriendgroupRepository(skynotedbEntities1 context)
            :base(context)
        {
        }

        public userfriendsgroup RetriveUserFriendsGroupPairsByUserId(int UserId)
        {
            return Context.Set<userfriendsgroup>()
                .FirstOrDefault(x => x.UserId == UserId);
        }
    }
}
