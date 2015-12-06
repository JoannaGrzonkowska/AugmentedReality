using CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Events
{
    public class ShareNoteInMultipleGroupsEvent : Event
    {
        public int NoteId { get; set; }
        public string GroupIds { get; set; }
        public int UserId { get; set; }

        public ShareNoteInMultipleGroupsEvent(int noteId, string groupIds, int userId)
        {
            NoteId = noteId;
            GroupIds = groupIds;
            UserId = userId;
        }
    }
}
