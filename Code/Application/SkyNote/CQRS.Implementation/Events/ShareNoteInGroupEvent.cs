using CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Events
{
    public class ShareNoteInGroupEvent : Event
    {
        public int NoteId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }

        public ShareNoteInGroupEvent(int noteId, int groupId, int userId)
        {
            NoteId = noteId;
            GroupId = groupId;
            UserId = userId;
        }
    }
}
