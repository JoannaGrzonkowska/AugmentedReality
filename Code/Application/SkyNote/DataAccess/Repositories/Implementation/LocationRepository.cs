using System.Linq;

namespace DataAccess.Repositories.Implementation
{
    public class LocationRepository : RepositoryBase<location, skynotedbEntities1>, ILocationRepository
    {

        public LocationRepository(skynotedbEntities1 context)
            :base(context)
        {
        }

        public location GetByCord(decimal xCord, decimal yCord)
        {
            return Context.Set<location>()
                .FirstOrDefault(x=>x.XCord==xCord && x.YCord==yCord);
        }
    }
}
