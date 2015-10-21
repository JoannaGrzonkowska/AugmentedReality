using CQRS.Commands;

namespace CQRS.Implementation.Commands
{
    public class CreateNoteCommand : Command
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }

        public CreateNoteCommand( int userId, int locationId, string topic,
            string content, int version)
            : base(0/*, version*/)
        {
            UserId = userId;
            LocationId = locationId;
            Topic = topic;
            Content = content;
        }
    }
}
