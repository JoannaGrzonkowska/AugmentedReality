using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class ShareNoteInGroupCommand : Command<notesgroups>
    {
        public int GroupId { get; set; }
        public int NoteId { get; set; }
        public int UserId { get; set; }

        public override notesgroups Build(notesgroups notesgroups = null, Action<notesgroups> additionalAction = null)
        {
            Action<notesgroups> action = x =>
            {
                x.GroupId = GroupId;
                x.NoteId = NoteId;
                x.UserId = UserId;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(notesgroups, action);
        }
    }
}
