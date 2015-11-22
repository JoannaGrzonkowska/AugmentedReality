using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Queries
{
    public class RetrieveGroupsNotesQuery : IQuery
    {
        public int GroupId { get; set; }

        public RetrieveGroupsNotesQuery(int groupId)
        {
            GroupId = groupId;
        }
    }
}
