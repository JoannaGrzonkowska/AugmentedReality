using AutoMapper;
using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;

namespace CQRS.Implementation.EventHandlers
{
    public class GroupCreatedEventHandler : IEventHandler<GroupCreatedEvent>
    {
        private readonly IGroupDenormalizedRepository groupDenormalizedRepository;

        public GroupCreatedEventHandler(IGroupDenormalizedRepository groupDenormalizedRepository)
        {
            this.groupDenormalizedRepository = groupDenormalizedRepository;
        }
        public void Handle(GroupCreatedEvent handle)
        {
            
            var item = Mapper.Map<group>(handle);

            groupDenormalizedRepository.Add(item);
            groupDenormalizedRepository.SaveChanges();
        }
    }
}

