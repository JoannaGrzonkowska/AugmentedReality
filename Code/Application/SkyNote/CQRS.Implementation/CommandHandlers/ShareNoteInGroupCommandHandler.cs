using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;
using System;
using System.Linq;

namespace CQRS.Implementation.CommandHandlers
{
    public class ShareNoteInGroupCommandHandler : ICommandHandler<ShareNoteInGroupCommand>
    {
        private IEventStorage _eventStorage;
        private INotegroupRepository _notegroupRepository;

        public ShareNoteInGroupCommandHandler(IEventStorage eventStorage, INotegroupRepository notegroupRepository)
        {
            _eventStorage = eventStorage;
            _notegroupRepository = notegroupRepository;
        }

        public CommandResult Execute(ShareNoteInGroupCommand command)
        {
            int[] GroupIdsArray = command.GroupIds.Split(';').Select(n => Convert.ToInt32(n)).ToArray();

            foreach (int groupId in GroupIdsArray)
            {
                var notessgroups = command.Build();
                notessgroups.GroupId = groupId;
                _notegroupRepository.Add(notessgroups);
                _notegroupRepository.SaveChanges();

                _eventStorage.Publish(new ShareNoteInGroupEvent(command.NoteId, groupId, command.UserId));
            }
        
            return new CommandResult();
        }
    }
}
