using System.Linq;

namespace DataAccess.Repositories
{
    public interface IUsergroupRepository : IRepositoryBase<usergroup>
    {
        IQueryable<usergroup> RetriveUserGroupPairsByUserId(int UserId);
        IQueryable<usergroup> RetriveUserGroupPairsByGroupId(int GroupId);
    }
}
