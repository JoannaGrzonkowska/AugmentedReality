using System;

namespace CQRS.Implementation.Models
{
    public class UserNoteDTO
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
    }
}
