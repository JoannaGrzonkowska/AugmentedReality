using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccess.Repositories;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;

namespace CQRS.Implementation.EventHandlers
{
    public class NoteCreatedEventHandler : IEventHandler<NoteCreatedEvent>
    {
        private readonly INoteDenormalizedRepository _noteDenormalizedRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITypeRepository _typeRepository;

        public NoteCreatedEventHandler(INoteDenormalizedRepository noteDenormalizedRepository, 
                                        IUserRepository userRepository, 
                                        ICategoryRepository categoryRepository, 
                                        ITypeRepository typeRepository)
        {
            _noteDenormalizedRepository =  noteDenormalizedRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _typeRepository = typeRepository;
        }
        public void Handle(NoteCreatedEvent handle)
        {
            var user = _userRepository.GetById(handle.UserId);

            string categoryName = null, typeName = null;
            int? categoryId=null;
            if (handle.TypeId != null) { 
                var type = _typeRepository.GetById((int)handle.TypeId);
                var category = _categoryRepository.GetById(type.CategoryId);
                categoryName = category.Name;
                typeName = type.Name;
                categoryId = category.CategoryId;
            }

            _noteDenormalizedRepository.InsertNote(
                handle.UserId,
                handle.Topic,
                handle.Content,
                handle.LocationId,
                handle.XCord,
                handle.YCord,
                handle.ZCord,
                user.Name,
                user.Login,
                user.Mail,
              0,
              string.Empty,
                "NOTE",
                handle.Date,
               handle.NoteId,
               categoryId,
                categoryName,
                handle.TypeId,
                typeName,
                handle.Address
                );
        }
    }
}

