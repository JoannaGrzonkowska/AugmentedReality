using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Implementation.Commands;
using CQRS.Implementation.Events;
using CQRS.Implementation.Services;
using DataAccess.Repositories;
using System.IO;
using System.Linq;

namespace CQRS.Implementation.CommandHandlers
{
    public class EditNoteCommandHandler : ICommandHandler<EditNoteCommand>
    {
        private INoteRepository noteRepository;
        private IEventStorage eventStorage;
        private IImageFileService imageFileService;

        public EditNoteCommandHandler(INoteRepository noteRepository, IEventStorage eventStorage, IImageFileService imageFileService)
        {
            this.noteRepository = noteRepository;
            this.eventStorage = eventStorage;
            this.imageFileService = imageFileService;
        }

        public CommandResult Execute(EditNoteCommand command)
        {
            var note = noteRepository.GetById(command.NoteId);
            var noteEdited = command.Build(note);
            noteRepository.SaveChanges();


            var destinationDirPath = Path.Combine(command.DestinationDirPath, note.Id.ToString());
            var usedFiles = command.Images.Where(x => !string.IsNullOrEmpty(x.Filename)).Select(x => x.Filename).ToList();
          
            imageFileService.DeleteUnusedFiles(usedFiles, destinationDirPath);
            imageFileService.SaveFilesList(command.Images.Where(x => x.ImageBytes!=null).ToList(), destinationDirPath);

            eventStorage.Publish(
                new NoteEditedEvent() {
                    NoteId = noteEdited.Id,
                    Topic = noteEdited.Topic,
                    Content = noteEdited.Content,
                    TypeId = noteEdited.TypeId,
                    Date = noteEdited.Date });

            return new CommandResult();
        }
    }
}
