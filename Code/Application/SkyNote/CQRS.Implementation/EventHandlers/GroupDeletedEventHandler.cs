using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized.Repository;
using System.Linq;

namespace CQRS.Implementation.EventHandlers
{
    public class GroupDeletedEventHandler : IEventHandler<GroupDeletedEvent>
    {
        private readonly IGroupDenormalizedRepository groupDenormalizedRepository;

        public GroupDeletedEventHandler(IGroupDenormalizedRepository groupDenormalizedRepository)
        {
            this.groupDenormalizedRepository = groupDenormalizedRepository;
        }

        public void Handle(GroupDeletedEvent handle)
        {
            var group = this.groupDenormalizedRepository.
                GetAllQueryable().FirstOrDefault(x => x.GroupId == handle.GroupId);

            this.groupDenormalizedRepository.Delete(group);
            this.groupDenormalizedRepository.SaveChanges();
        }
    }
}
