using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSync.DAL.Entities
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeCode { get; set; }
        [MaxLength(120)]
        public string DocumentTypeName { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        [MaxLength(1)]
        [Required]
        public string IsUsed { get; set; } = null!;
        
    }
}