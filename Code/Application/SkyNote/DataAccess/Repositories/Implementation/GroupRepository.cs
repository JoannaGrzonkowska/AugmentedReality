namespace DataAccess.Repositories.Implementation
{
    public class GroupRepository : RepositoryBase<group, skynotedbEntities1>, IGroupRepository
    {
        public GroupRepository(skynotedbEntities1 context)
            :base(context)
        {

        }


    }
}
