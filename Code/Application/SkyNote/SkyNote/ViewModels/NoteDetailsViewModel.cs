using CQRS.Implementation.Models;
using System.Collections.Generic;

namespace SkyNote.ViewModels
{
    public class NoteDetailsViewModel
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public NoteDTO Note { get; set; }
    }
}