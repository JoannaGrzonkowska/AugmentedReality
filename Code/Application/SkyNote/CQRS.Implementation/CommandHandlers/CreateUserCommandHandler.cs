using CQRS.CommandHandlers;
using CQRS.Implementation.Commands;
using CQRS.Commands;
using DataAccess.Repositories;
using CQRS.Events;
using CQRS.Implementation.Events;
using DataAccess;
using CQRS.Implementation.Static;
using System.IO;
using CQRS.Implementation.Services;

namespace CQRS.Implementation.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private IUserRepository userRepository;
        private IGroupRepository groupRepository;
        private IUserfriendgroupRepository userfriendgrouRepository;
        private IEventStorage eventStorage;
        private IImageFileService imageFileService;
        

        public CreateUserCommandHandler(IUserRepository userRepository, 
            IGroupRepository groupRepository, 
            IUserfriendgroupRepository userfriendgrouRepository, 
            IEventStorage eventStorage, 
            IImageFileService imageFileService)
        {
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.userfriendgrouRepository = userfriendgrouRepository;
            this.eventStorage = eventStorage;
            this.imageFileService = imageFileService;
        }

        public CommandResult Execute(CreateUserCommand command)
        {
            var user = command.Build();
            var filename = user.Login + StaticData.FilesExtension;
            var serverPath = Path.Combine(Path.GetDirectoryName(command.avatarPath), filename);
            imageFileService.SaveFile(File.ReadAllBytes(command.avatarPath), serverPath);

            user.Avatar = filename;
            userRepository.Add(user);
            userRepository.SaveChanges();

            var groupCommand = new CreateGroupCommand();
            groupCommand.UserId = user.UserID;
            groupCommand.Name = "FriendsOf"+user.Name;
            var group = groupCommand.Build();
            groupRepository.Add(group);
            groupRepository.SaveChanges();

            userfriendgrouRepository.Add(new userfriendsgroup() {UserId = user.UserID, GroupId=group.Id });
            userfriendgrouRepository.SaveChanges();

            eventStorage.Publish(
                new GroupCreatedEvent(group.Id, group.Name, "OWNER",
                user.UserID, user.Name, user.Login, user.Mail));            

            return new CommandResult();
        }
    }
}
