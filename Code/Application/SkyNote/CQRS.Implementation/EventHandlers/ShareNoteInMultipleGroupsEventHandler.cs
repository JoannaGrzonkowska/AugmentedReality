using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccessDenormalized.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.EventHandlers
{
    public class ShareNoteInMultipleGroupsEventHandler : IEventHandler<ShareNoteInMultipleGroupsEvent>
    {
        private readonly INoteDenormalizedRepository _noteDenormalizedRepository;

        public ShareNoteInMultipleGroupsEventHandler(INoteDenormalizedRepository noteDenormalizedRepository)
        {
            _noteDenormalizedRepository = noteDenormalizedRepository;
        }

        public void Handle(ShareNoteInMultipleGroupsEvent handle)
        {
            var sharedNote = _noteDenormalizedRepository.GetAllQueryable().FirstOrDefault(x => x.NoteId == handle.NoteId);
            if(sharedNote.GroupIds == null)
                sharedNote.GroupIds = handle.GroupIds;
            else
            {
                int[] newGroupIdsArray = handle.GroupIds.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
                int[] oldGroupIdsArray = sharedNote.GroupIds.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
                foreach(int newId in newGroupIdsArray)
                    if (!oldGroupIdsArray.Contains(newId))
                        sharedNote.GroupIds += (";" +newId.ToString());
            }

            _noteDenormalizedRepository.SaveChanges();

        }
    }
}
