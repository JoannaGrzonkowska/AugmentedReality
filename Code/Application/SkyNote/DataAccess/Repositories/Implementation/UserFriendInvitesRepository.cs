using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class UserFriendInvitesRepository : RepositoryBase<userfriendsinvites, skynotedbEntities1>, IUserFriendInvitesRepository
    {
        public UserFriendInvitesRepository(skynotedbEntities1 context)
            :base(context)
        {
        }

        public userfriendsinvites GetPendingInvites(int UserId)
        {
            return Context.Set<userfriendsinvites>()
                .FirstOrDefault(x => x.UserId == UserId && x.State == "PENDING");
        }

        public userfriendsinvites GetParticularInvite(int InvitedId, int InvitingId)
        {
            return Context.Set<userfriendsinvites>()
                .FirstOrDefault(x => x.UserId == InvitingId && x.FriendId== InvitedId && x.State == "PENDING");
        }
    }
}
