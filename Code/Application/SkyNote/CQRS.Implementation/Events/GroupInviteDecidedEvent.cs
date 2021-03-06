﻿using CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Events
{
    public class GroupInviteDecidedEvent : Event
    {
        public int GroupId { get; set; }
        public int InvitedId { get; set; }
        public int InvitingId { get; set; }
        public string State { get; set; }
    }
}
