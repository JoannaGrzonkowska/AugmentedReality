using CQRS.Implementation.Models;
using System.Collections.Generic;

namespace SkyNote.ViewModels
{
    public class NotesByLocationViewModel
    {
        public IEnumerable<UserGroupDTO> Groups { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<NoteDTO> Notes { get; set; }
    }
}