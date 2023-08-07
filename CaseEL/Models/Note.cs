using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEL.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }        
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Note? Parent { get; set; }
        public bool IsDeleted { get; set; }

    }
}
