using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class CreateNoteCommand : Command<note>
    {
        public int UserId { get; set; }
        public decimal xCord { get; set; }
        public decimal yCord { get; set; }
        public decimal zCord { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }

        public override note Build(note noteParam = null, Action<note> action = null)
        {
            var note = noteParam ?? new note();
            note.Content = Content;
            note.Topic = Topic;
            note.UserId = UserId;
           // note.LocationId = LocationId;
            note.Date = DateTime.Now;

            if (action != null)
            {
                action(note);
            }

            return note;
        }
    }
}
