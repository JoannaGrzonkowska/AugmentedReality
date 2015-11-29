using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class UserfriendsRepository : RepositoryBase<userfriends, skynotedbEntities1>, IUserfriendsRepository
    {
        public UserfriendsRepository(skynotedbEntities1 context)
            :base(context)
        {
        }

        public userfriends RetriveUserFriendsPairsByUserId(int UserId)
        {
            return Context.Set<userfriends>()
                .FirstOrDefault(x => x.UserId == UserId);
        }
    }
}
