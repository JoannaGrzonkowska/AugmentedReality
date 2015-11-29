using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS.Implementation.Models;

namespace SkyNote.ViewModels
{
    public class MyNotesViewModel
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<NoteDTO> Notes { get; set; }
    }
}