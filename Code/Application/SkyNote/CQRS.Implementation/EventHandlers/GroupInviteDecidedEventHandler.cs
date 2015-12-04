using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.EventHandlers
{
    public class GroupInviteDecidedEventHandler : IEventHandler<GroupInviteDecidedEvent>
    {
        private IInvitesDenormalizedRepository inviteRepository;

        public GroupInviteDecidedEventHandler(IInvitesDenormalizedRepository inviteRepository)
        {
            this.inviteRepository = inviteRepository;
        }

        public void Handle(GroupInviteDecidedEvent handle)
        {
            var inv = inviteRepository.GetAllQueryable().FirstOrDefault(
                x => x.UserId == handle.InvitingId
                && x.FriendId == handle.InvitedId
                && x.GroupId == handle.GroupId
                && x.State == "PENDING");

            if (inv != null)
            {
                inv.State = handle.State;
                inviteRepository.SaveChanges();
            }
        }
    }
}
