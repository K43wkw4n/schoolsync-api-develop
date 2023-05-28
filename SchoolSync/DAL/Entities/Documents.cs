using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSync.DAL.Entities
{
    public class Documents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        [MaxLength(20)]
        public string DocumentCode { get; set; } = null!;
        [MaxLength(2)]
        public int? DocumentTypeCode { get; set; }
        public DateTime DocumentDate { get; set; }
        [MaxLength(80)]
        public string DocumentOfDivision { get; set; } = null!;
        [MaxLength(120)]
        public string Title { get; set; } = null!; 
        public string Detail { get; set; } = null!;
        [MaxLength(20)]
        public string AttachFile { get; set; } = null!;
        public DateTime CreatedDate { get; set; } 
        [MaxLength(1)]
        public string IsUsed { get; set; } = null!;

    }
}