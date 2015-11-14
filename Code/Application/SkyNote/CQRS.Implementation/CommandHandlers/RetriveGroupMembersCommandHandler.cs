using System;
using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Implementation.Commands;
using DataAccess.Repositories;
using System.Linq;
using DataAccess;
using System.Collections.Generic;

namespace CQRS.Implementation.CommandHandlers
{
    public class RetriveGroupMembersCommandHandler : ICommandHandler<RetriveGroupMembersCommand>
    {
        private IUsergroupRepository usegroupRepository;
        private IUserRepository userRepository;

        public RetriveGroupMembersCommandHandler(IUsergroupRepository usegroupRepository, IUserRepository userRepository)
        {
            this.usegroupRepository = usegroupRepository;
            this.userRepository = userRepository;
        }

        public CommandResult Execute(RetriveGroupMembersCommand command)
        {
            IQueryable<usergroup> userGroupPairs = this.usegroupRepository.RetriveUserGroupPairsByGroupId(command.GroupId);
            if (userGroupPairs != null)
            {
                List<int> GroupsIdList = new List<int>();
                foreach (usergroup pair in userGroupPairs)
                    GroupsIdList.Add(pair.GroupId);
                IQueryable<user> userGroups = userRepository.RetriveUsersByIds(GroupsIdList);
            }

            return new CommandResult();
        }
    }
}
