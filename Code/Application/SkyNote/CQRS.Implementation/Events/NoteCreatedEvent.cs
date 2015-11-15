using CQRS.Events;
using System;

namespace CQRS.Implementation.Events
{
    public class NoteCreatedEvent : Event
    {
        public int UserId { get; set; }
        public int NoteId { get; set; }
public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public decimal? XCord { get; set; }
        public decimal? YCord { get; set; }
        public decimal? ZCord { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }

        public NoteCreatedEvent(
            int id, int userId, DateTime? date, int locationId, decimal? xCord, decimal? yCord, decimal? zCord,
            string topic, string content, string name, string login, string mail)
        {
            AggregateId = id;
            UserId = userId;
            Date = date;
            LocationId = locationId;
            XCord = xCord;
            YCord = yCord;
            ZCord = zCord;
            Topic = topic;
            Content = content;
            Name = name;
            Login = login;
            Mail = mail;
        }
    }
}
