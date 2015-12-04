using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class UserGroupInvitesRepository : RepositoryBase<usergroupinvites, skynotedbEntities1>, IUserGroupInvitesRepository
    {
        public UserGroupInvitesRepository(skynotedbEntities1 context)
            :base(context)
        {
        }

        public usergroupinvites GetPendingInvites(int UserId)
        {
            return Context.Set<usergroupinvites>()
                .FirstOrDefault(x => x.UserId == UserId && x.State == "PENDING");
        }

        public usergroupinvites GetParticularInvite(int InvitedId, int InvitingId, int GroupId)
        {
            return Context.Set<usergroupinvites>()
                .FirstOrDefault(x => x.UserId == InvitingId && x.InvatedId == InvitedId && x.GroupId == GroupId && x.State == "PENDING");
        }
    }
}
