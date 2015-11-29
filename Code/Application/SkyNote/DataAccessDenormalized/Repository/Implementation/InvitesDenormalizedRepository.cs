using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDenormalized.Repository.Implementation
{
    public class InvitesDenormalizedRepository : Repository<invites, skynotedenormalizeddbEntities>, IInvitesDenormalizedRepository
    {
        public InvitesDenormalizedRepository(skynotedenormalizeddbEntities context)
            : base(context)
        {

        }
    }
}
