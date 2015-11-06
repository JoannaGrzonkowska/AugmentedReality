using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class CreateGroupCommand : Command<group>
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public override group Build(group group = null, Action<group> additionalAction = null)
        {
            Action<group> action = x =>
            {
                x.Id = GroupId;
                x.Name = Name;

                if (additionalAction != null)
                {
                    additionalAction(x);
                }
            };
            return base.Build(group, action);
        }
           
    }
}
