using CQRS.CommandHandlers;
using CQRS.Implementation.Commands;
using System;
using CQRS.Commands;
using DataAccess.Repositories;
using CQRS.Events;
using DataAccess;
using System.Linq;
using CQRS.Implementation.Events;

namespace CQRS.Implementation.CommandHandlers
{
    public class DecideGroupInviteCommandHandler : ICommandHandler<DecideGroupInviteCommand>
    {
        private IUserGroupInvitesRepository groupInvitesRepository;
        private IUsergroupRepository userGroupStorage;
        private IUserRepository userStorage;
        private IGroupRepository groupStorage;
        private IEventStorage eventStorage;

        public DecideGroupInviteCommandHandler(IUserGroupInvitesRepository groupInvitesRepository, IUsergroupRepository userGroupStorage, IUserRepository userStorage, IGroupRepository groupStorage, IEventStorage eventStorage)
        {
            this.groupInvitesRepository = groupInvitesRepository;
            this.userGroupStorage = userGroupStorage;
            this.eventStorage = eventStorage;
            this.groupStorage = groupStorage;
            this.userStorage = userStorage;
        }

        public CommandResult Execute(DecideGroupInviteCommand command)
        {
            var groupInvite = groupInvitesRepository.GetParticularInvite(command.InvatedUserId, command.InvatingUserId, command.GroupId);
            var groupInviteDecided = command.Build(groupInvite);
            groupInvitesRepository.SaveChanges();

            if (command.State == "ACCEPT")
            {
                usergroup membership = new usergroup() { UserId = command.InvatedUserId, GroupId = command.GroupId };
                userGroupStorage.Add(membership);
                userGroupStorage.SaveChanges();

                user user = this.userStorage.GetById(command.InvatedUserId);
                group group = this.groupStorage.GetById(command.GroupId);

                if (user != null && group != null)
                {

                    eventStorage.Publish(new UserJoinGroupEvent(
                        user.UserID, group.Id, "MEMBER",
                        group.Name, user.Name, user.Login, user.Mail
                    ));
                }
            }

            eventStorage.Publish(
                new GroupInviteDecidedEvent()
                {
                    State = command.State,
                    InvitedId = command.InvatedUserId,
                    InvitingId = command.InvatingUserId,
                    GroupId = command.GroupId
                }
            );
            return new CommandResult();
        }
    }
}
