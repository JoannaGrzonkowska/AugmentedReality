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
    public class UserRemoveFriendEventHandler : IEventHandler<UserRemoveFriendEvent>
    {
        private readonly IGroupDenormalizedRepository groupRepository;

        public UserRemoveFriendEventHandler(IGroupDenormalizedRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public void Handle(UserRemoveFriendEvent handle)
        {
            var userFriend = groupRepository.GetAllQueryable().FirstOrDefault(x => x.UserId == handle.UserId 
                                                                                && x.FriendId == handle.FriendId);
            if (userFriend != null)
            {
                groupRepository.Delete(userFriend);
                groupRepository.SaveChanges();
            }
        }
    }
}
