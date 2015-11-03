using CQRS.Commands;
using DataAccess;

namespace CQRS.Implementation.Commands
{
    public class CreateGroupCommand : Command<group>
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public override group Build()
        {
            return new group
            {
                Id = GroupId,
                Name = Name
                
            };
        }
    }
}
