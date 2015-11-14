using CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Events
{
    public class UserJoinGroupEvent : Event
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; }

        public UserJoinGroupEvent(int userId, int groupId, string role)
        {
            this.UserId = userId;
            this.GroupId = groupId;
            this.Role = role;
        }
    }
}
