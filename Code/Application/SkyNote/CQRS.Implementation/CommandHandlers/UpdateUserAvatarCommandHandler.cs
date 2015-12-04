using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using CQRS.Implementation.Services;
using CQRS.Implementation.Static;
using DataAccess.Repositories;
using System.IO;

namespace CQRS.Implementation.CommandHandlers
{
    public class UpdateUserAvatarCommandHandler : ICommandHandler<UpdateUserAvatarCommand>
    {
        private IEventStorage eventStorage;
        private IUserRepository userRepository;
        private IImageFileService imageFileService;

        public UpdateUserAvatarCommandHandler(IEventStorage eventStorage, IUserRepository userRepository, IImageFileService imageFileService)
        {
            this.eventStorage = eventStorage;
            this.userRepository = userRepository;
            this.imageFileService = imageFileService;
        }

        public CommandResult Execute(UpdateUserAvatarCommand command)
        {
           var user = userRepository.GetById(command.UserId);

           var filename = user.Login + StaticData.FilesExtension;
           var serverPath = Path.Combine(command.DestinationDirPath, filename);
           imageFileService.SaveFile(command.ImageBytes, serverPath);

            user.Avatar = filename;
            userRepository.SaveChanges();

            return new CommandResult();
        }
    }
}
