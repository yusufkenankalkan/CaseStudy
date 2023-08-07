using CaseEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEL.ViewModels
{
    public class NoteVM
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? ParentId { get; set; }
        public bool IsDeleted { get; set; }
        public List<NoteVM>? Children { get; set; }
        public NoteVM? Parent { get; set; }
    }
}
