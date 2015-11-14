using AutoMapper;
using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;

namespace CQRS.Implementation.EventHandlers
{
    public class UserJoinGroupEventHandler : IEventHandler<UserJoinGroupEvent>
    {
        private readonly IGroupDenormalizedRepository groupDenormalizedRepository;

        public UserJoinGroupEventHandler(IGroupDenormalizedRepository groupDenormalizedRepository)
        {
            this.groupDenormalizedRepository = groupDenormalizedRepository;
        }

        public void Handle(UserJoinGroupEvent handle)
        {
            var item = Mapper.Map<group>(handle);//HERE IT FAILS!

            groupDenormalizedRepository.Add(item);
            groupDenormalizedRepository.SaveChanges();
        }
    }
}
