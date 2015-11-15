using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Models
{
    public class FriendDTO
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public string FriendName { get; set; }
        public string FriendLogin { get; set; }
        public string FriendMail { get; set; }
    }
}
