using CQRS.EventHandlers;
using CQRS.Implementation.Events;
using DataAccess.Repositories;
using DataAccessDenormalized;
using DataAccessDenormalized.Repository;
using System.Linq;

namespace CQRS.Implementation.EventHandlers
{
    public class NoteEditedEventHandler : IEventHandler<NoteEditedEvent>
    {
        private readonly INoteDenormalizedRepository _noteDenormalizedRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITypeRepository _typeRepository;

        public NoteEditedEventHandler(INoteDenormalizedRepository noteDenormalizedRepository,
            ICategoryRepository categoryRepository,
            ITypeRepository typeRepository)
        {
            _noteDenormalizedRepository = noteDenormalizedRepository;
            _categoryRepository = categoryRepository;
            _typeRepository = typeRepository;
        }
        public void Handle(NoteEditedEvent handle)
        {
            string categoryName = null, typeName = null;
            int? categoryId = null;
            if (handle.TypeId != null)
            {
                var type = _typeRepository.GetById((int)handle.TypeId);
                var category = _categoryRepository.GetById(type.CategoryId);
                categoryName = category.Name;
                typeName = type.Name;
                categoryId = category.CategoryId;
            }

            var note = _noteDenormalizedRepository.GetAllQueryable().FirstOrDefault(x => x.NoteId == handle.NoteId);
            note.Content = handle.Content;
            note.Topic = handle.Topic;
            note.Date = handle.Date;
            note.TypeId = handle.TypeId;
            note.TypeName = typeName;
            note.CategoryId = categoryId;
            note.CategoryName = categoryName;

            _noteDenormalizedRepository.SaveChanges();
        }
    }
}