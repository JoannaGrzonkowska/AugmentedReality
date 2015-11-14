using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.CommandHandlers
{
    public class UserJoinGroupCommandHandler : ICommandHandler<UserJoinGroupCommand>
    {
        private IUsergroupRepository usegroupRepository;
        private ILocationRepository locationRepository;
        private IEventStorage eventStorage;

        public UserJoinGroupCommandHandler(IUsergroupRepository usegroupRepository, ILocationRepository locationRepository, IEventStorage eventStorage)
        {
            this.usegroupRepository = usegroupRepository;
            this.locationRepository = locationRepository;
            this.eventStorage = eventStorage;
        }

        public CommandResult Execute(UserJoinGroupCommand command)
        {
            var usergroup = command.Build();

            usegroupRepository.Add(usergroup);
            usegroupRepository.SaveChanges();
            eventStorage.Publish(new UserJoinGroupEvent(usergroup.UserId, usergroup.GroupId, "Member"));

            return new CommandResult();
        }

    }
}
