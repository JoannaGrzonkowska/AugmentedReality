using AutoMapper;
using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.EventHandlers
{
    public class UserGroupInviteEventHandler : IEventHandler<UserGroupInviteEvent>
    {
        private IInvitesDenormalizedRepository invitesStorage;

        public UserGroupInviteEventHandler(IInvitesDenormalizedRepository invitesStorage)
        {
            this.invitesStorage = invitesStorage;
        }

        public void Handle(UserGroupInviteEvent handle)
        {
            var item = Mapper.Map<invites>(handle);

            invitesStorage.Add(item);
            invitesStorage.SaveChanges();
        }
    }
}
