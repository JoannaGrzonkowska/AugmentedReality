using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class EditNoteCommand : Command<note>
    {
        public int NoteId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public int TypeId { get; set; }

        public override note Build(note note = null, Action<note> additionalAction = null)
        {
            Action<note> action = x =>
            {
                x.Content = Content;
                x.Topic = Topic;
                x.Date = DateTime.Now;
                x.TypeId = TypeId;
            };
            return base.Build(note, action);
        }
    }
}
