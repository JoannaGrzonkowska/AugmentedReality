namespace DataAccess.Repositories
{
    public interface IUserFriendInvitesRepository : IRepositoryBase<userfriendsinvites>
    {
        userfriendsinvites GetPendingInvites(int UserId);
        userfriendsinvites GetParticularInvite(int InvitedId, int InvitingId);
    }
}
