using System;

namespace DataAccessDenormalized.Repository
{
    public class NoteDenormalizedRepository : Repository<note, skynotedenormalizeddbEntities>, INoteDenormalizedRepository
    {

        public NoteDenormalizedRepository(skynotedenormalizeddbEntities context)
            :base(context)
        {

        }

        
    }
}
