using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class NotegroupRepository : RepositoryBase<notesgroups, skynotedbEntities1>, INotegroupRepository
    {
        public NotegroupRepository(skynotedbEntities1 context)
            :base(context)
        {
        }

        public IQueryable<notesgroups> RetriveNotesGroupPairsByGroupId(int GroupId)
        {
            return Context.Set<notesgroups>()
                .Where(x => x.GroupId == GroupId);
        }
    }
}
