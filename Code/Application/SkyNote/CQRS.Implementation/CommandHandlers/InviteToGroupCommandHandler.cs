using CQRS.CommandHandlers;
using CQRS.Implementation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Commands;
using DataAccess.Repositories;
using CQRS.Events;
using DataAccess;
using CQRS.Implementation.Events;

namespace CQRS.Implementation.CommandHandlers
{
    public class InviteToGroupCommandHandler : ICommandHandler<InviteToGroupCommand>
    {
        private IUserGroupInvitesRepository userGroupInvitesStorage;
        private IGroupRepository groupStorage;
        private IUserRepository userStorage;
        private IEventStorage eventStorage;

        public InviteToGroupCommandHandler(IUserGroupInvitesRepository userGroupInvitesStorage, IGroupRepository groupStorage, IUserRepository userStorage, IEventStorage eventStorage)
        {
            this.userGroupInvitesStorage = userGroupInvitesStorage;
            this.groupStorage = groupStorage;
            this.userStorage = userStorage;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(InviteToGroupCommand command)
        {
            var usergroupinv = command.Build();

            userGroupInvitesStorage.Add(usergroupinv);
            userGroupInvitesStorage.SaveChanges();

            user userInvating = userStorage.GetById(command.UserId);
            user userInvated = userStorage.GetById(command.InvatedId);
            group groups = groupStorage.GetById(command.GroupId);

            if (userInvating != null && userInvated != null && groups != null)
            {

                eventStorage.Publish(new UserGroupInviteEvent(
                    userInvating.UserID, userInvating.Name, userInvating.Login, userInvating.Mail,
                    userInvated.UserID, userInvated.Name, userInvated.Login, userInvated.Mail,
                    groups.Id, groups.Name
                    ));
            }

            return new CommandResult();
        }
    }
}
