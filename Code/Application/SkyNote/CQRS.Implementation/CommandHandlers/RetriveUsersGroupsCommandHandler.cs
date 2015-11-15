using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Implementation.Commands;
using DataAccess;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.CommandHandlers
{
    public class RetriveUsersGroupsCommandHandler : ICommandHandler<RetriveUsersGroupsCommand>
    {
        private IUsergroupRepository usegroupRepository;
        private IGroupRepository groupRepository;

        public RetriveUsersGroupsCommandHandler(IUsergroupRepository usegroupRepository, IGroupRepository groupRepository)
        {
            this.usegroupRepository = usegroupRepository;
            this.groupRepository = groupRepository;
        }

        public CommandResult Execute(RetriveUsersGroupsCommand command)
        {
            IQueryable<usergroup> userGroupPairs = usegroupRepository.RetriveUserGroupPairsByUserId(command.UserId);
            if(userGroupPairs != null)
            {
                List<int> GroupsIdList = new List<int>();
                foreach(usergroup pair in userGroupPairs)
                {
                    GroupsIdList.Add(pair.GroupId);
                }

                IQueryable<group> userGroups = groupRepository.RetriveGroupsByIds(GroupsIdList);
            }
            
            return new CommandResult();
        }
    }
}
