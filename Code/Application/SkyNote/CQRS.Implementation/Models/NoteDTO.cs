using System;

namespace CQRS.Implementation.Models
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public decimal? XCord { get; set; }
        public decimal? YCord { get; set; }
        public decimal? ZCord { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
