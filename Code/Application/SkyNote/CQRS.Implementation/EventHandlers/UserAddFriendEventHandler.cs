using AutoMapper;
using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;

namespace CQRS.Implementation.EventHandlers
{
    public class UserAddFriendEventHandler : IEventHandler<UserAddFriendEvent>
    {
        private readonly IGroupDenormalizedRepository groupDenormalizedRepository;

        public UserAddFriendEventHandler(IGroupDenormalizedRepository groupDenormalizedRepository)
        {
            this.groupDenormalizedRepository = groupDenormalizedRepository;
        }

        public void Handle(UserAddFriendEvent handle)
        {
            var item = Mapper.Map<group>(handle);

            groupDenormalizedRepository.Add(item);
            groupDenormalizedRepository.SaveChanges(); 
        }
    }
}
