using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
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
            List<group> groups = this.groupDenormalizedRepository.
                GetAllQueryable().Where(x => x.GroupId == handle.GroupId).ToList();

            foreach (group group in groups)
                this.groupDenormalizedRepository.Delete(group);
            this.groupDenormalizedRepository.SaveChanges();
        }
    }
}
