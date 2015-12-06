using CQRS.Implementation.Models;
using System.Collections.Generic;

namespace SkyNote.ViewModels
{
    public class NotesByLocationModel
    {
        public IEnumerable<int> NotesToDelete { get; set; }
        public IEnumerable<NoteDTO> Notes { get; set; }
    }
}