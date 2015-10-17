using System;

namespace CQRS.Commands
{
    public class Command : ICommand
    {
        public int Id{ get; private set; }
        //public int Version { get; private set; }
        public Command(int id/*, int version*/)
        {
            Id = id;
            //Version = version;
        }
    }
}
