using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class LocationRepository : RepositoryBase<location, skynotedbEntities1>, ILocationRepository
    {

        public LocationRepository(skynotedbEntities1 context)
            :base(context)
        {

        }
    }
}
