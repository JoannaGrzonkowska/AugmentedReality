using CQRS.Implementation.Models;
using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Queries
{
    public class RetrieveGroupInvitesQueryResult : IQueryResult
    {
        public IEnumerable<GroupInviteDTO> GroupInvates { get; set; }
    }
}
