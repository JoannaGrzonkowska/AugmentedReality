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
        public int TypeId { get; set; }
        public int CategoryId { get; set; }

        public override note Build(note note = null, Action<note> additionalAction = null)
        {
            Action<note> action = x =>
            {
                x.Content = Content;
                x.Topic = Topic;
                x.UserId = UserId;
                x.Date = DateTime.Now;
                x.TypeId = 1;//TypeId;
                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(note, action);
        }
    }
}
