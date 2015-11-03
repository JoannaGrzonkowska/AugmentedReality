namespace DataAccessDenormalized.Repository.Implementation
{
    public class GroupDenormalizedRepository : Repository<group, skynotedenormalizeddbEntities>, IGroupDenormalizedRepository
    {
        public GroupDenormalizedRepository(skynotedenormalizeddbEntities context)
            : base(context)
        {

        }
    }
}
