namespace DataAccess.Repositories
{
    public interface IUserGroupInvitesRepository : IRepositoryBase<usergroupinvites>
    {
        usergroupinvites GetPendingInvites(int UserId);
        usergroupinvites GetParticularInvite(int InvitedId, int InvitingId, int GroupId);
    }
}
