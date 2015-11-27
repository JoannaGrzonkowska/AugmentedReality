using CQRS.Commands;
using DataAccess;
using System;

namespace CQRS.Implementation.Commands
{
    public class UpdateUserAvatarCommand : Command<group>
    {
        public int UserId { get; set; }
        public byte[] ImageBytes { get; set; }
        public string ImageBase64 { get; set; }
        public string DestinationDirPath { get; set; }
        public string ImageExtension { get; set; }

           
    }
}
