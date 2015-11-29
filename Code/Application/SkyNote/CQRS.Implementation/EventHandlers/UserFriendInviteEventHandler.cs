using AutoMapper;
using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized.Repository;
using DataAccessDenormalized;

namespace CQRS.Implementation.EventHandlers
{
    public class UserFriendInviteEventHandler : IEventHandler<UserFriendInviteEvent>
    {
        private IInvitesDenormalizedRepository invitesStorage;

        public UserFriendInviteEventHandler(IInvitesDenormalizedRepository invitesStorage)
        {
            this.invitesStorage = invitesStorage;
        }

        public void Handle(UserFriendInviteEvent handle)
        {
            var item = Mapper.Map<invites>(handle);

            invitesStorage.Add(item);
            invitesStorage.SaveChanges();
        }
    }
}
