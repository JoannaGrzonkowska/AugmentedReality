using CQRS.Commands;
using DataAccess;

namespace CQRS.Implementation.Commands
{
    public class DeleteGroupCommand : Command<group>
    {
        public int GroupId { get; set; }
    }
}
