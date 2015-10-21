using System;

namespace DataAccessDenormalized.Repository
{
    public class NoteDenormalizedRepository : Repository<notedto, skynotedenormalizeddbEntities1>, INoteDenormalizedRepository
    {

        public NoteDenormalizedRepository(skynotedenormalizeddbEntities1 context)
            :base(context)
        {

        }

        
    }
}
