namespace DataAccess.Repositories
{
    public interface IUserGroupInvitesRepository : IRepositoryBase<usergroupinvites>
    {
        usergroupinvites GetPendingInvites(int UserId);
    }
}
