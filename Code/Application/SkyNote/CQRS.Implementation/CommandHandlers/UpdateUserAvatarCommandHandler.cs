using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using DataAccess.Repositories;
using System.IO;

namespace CQRS.Implementation.CommandHandlers
{
    public class UpdateUserAvatarCommandHandler : ICommandHandler<UpdateUserAvatarCommand>
    {
        private IEventStorage eventStorage;
        private IUserRepository userRepository;

        public UpdateUserAvatarCommandHandler(IEventStorage eventStorage, IUserRepository userRepository)
        {
            this.eventStorage = eventStorage;
            this.userRepository = userRepository;
        }

        public CommandResult Execute(UpdateUserAvatarCommand command)
        {

         //   var geek = _geekRepository.GetById(command.GeekId);

            var filename = "asia.jpg";// _assetsHelper.GetGeekPhotoFilename(geek.ExternalId) + command.ImageExtension;
            var serverPath = Path.Combine(command.DestinationDirPath, filename);
            var imageFileService = new ImageFileService();
            imageFileService.SaveFile(command.ImageBytes, serverPath);

         /*   geek.AvatarFilename = filename;
            _geekRepository.Update(geek);
            _unitOfWork.SaveChanges();*/

            return new CommandResult();
        }
    }

    public class ImageFileService //: IImageFileService
    {
        public FileStream Get(string fileName, string destinationPath)
        {
            if (!Directory.Exists(destinationPath))
            {
                throw new DirectoryNotFoundException("Missing directory for keeping files");
            }

            var serverPath = Path.Combine(destinationPath, fileName);

            return File.OpenRead(serverPath);
        }

        public void SaveFile(byte[] bytes, string filePath)
        {
            CreateDirIfNotExsists(filePath);
            File.WriteAllBytes(filePath, bytes);
        }

        private void CreateDirIfNotExsists(string filePath)
        {
            var dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
