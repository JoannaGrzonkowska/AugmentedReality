using CQRS.Commands;
using CQRS.Implementation.Commands.Models;
using DataAccess;
using System;
using System.Collections.Generic;

namespace CQRS.Implementation.Commands
{
    public class EditNoteCommand : Command<note>
    {
        public int NoteId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public int TypeId { get; set; }

        public string DestinationDirPath { get; set; }
        public IList<SaveImageModel> Images { get; set; }

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
