using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class CreateNoteCommand : Command<note>
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }

        public override note Build()
        {
            return new note
            {
                Content = Content,
                Topic = Topic,
                UserId = UserId,
                LocationId = LocationId,
                Date = DateTime.Now
            };
        }
    }
}
