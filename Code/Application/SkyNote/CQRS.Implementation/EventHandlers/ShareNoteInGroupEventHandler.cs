using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccess.Repositories;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;

namespace CQRS.Implementation.EventHandlers
{
    public class ShareNoteInGroupEventHandler : IEventHandler<ShareNoteInGroupEvent>
    {
        private readonly INoteDenormalizedRepository _noteDenormalizedRepository;
        private readonly IUserRepository _userRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly ILocationRepository _locationRepository;

        public ShareNoteInGroupEventHandler(INoteDenormalizedRepository noteDenormalizedRepository,
                                        IUserRepository userRepository,
                                        ICategoryRepository categoryRepository,
                                        ITypeRepository typeRepository,
                                        INoteRepository noteRepository,
                                        IGroupRepository groupRepository,
                                        ILocationRepository locationRepository)
        {
            _noteDenormalizedRepository = noteDenormalizedRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _typeRepository = typeRepository;
            _noteRepository = noteRepository;
            _groupRepository = groupRepository;
            _locationRepository = locationRepository;
        }

        public void Handle(ShareNoteInGroupEvent handle)
        {
            var sharedNote = _noteRepository.GetById(handle.NoteId);
            var group = _groupRepository.GetById(handle.GroupId);
            var user = _userRepository.GetById(handle.UserId);
            var location = _locationRepository.GetById((int)sharedNote.LocationId);

            string categoryName = null, typeName = null;
            int? categoryId = null;
            if (sharedNote.TypeId != null)
            {
                var type = _typeRepository.GetById((int)sharedNote.TypeId);
                var category = _categoryRepository.GetById(type.CategoryId);
                categoryName = category.Name;
                typeName = type.Name;
                categoryId = category.CategoryId;
            }

            var item = new note()
            {
                GroupId = handle.GroupId,
                GroupName = group.Name,
                NoteId = handle.NoteId,
                Content = sharedNote.Content,
                Topic = sharedNote.Topic,
                UserId = handle.UserId,
                LocationId = (int)sharedNote.LocationId,
                Date = sharedNote.Date,
                XCord = location.XCord,
                YCord = location.YCord,
                ZCord = location.ZCord,
                Login = user.Login,
                Mail = user.Mail,
                Name = user.Name,
                Identyfication = "NOTE_SHARED_IN_GROUP",
                TypeId = sharedNote.TypeId,
                TypeName = typeName,
                CategoryId = categoryId,
                CategoryName = categoryName
            };

            _noteDenormalizedRepository.Add(item);
            _noteDenormalizedRepository.SaveChanges();

        }
    }
}
