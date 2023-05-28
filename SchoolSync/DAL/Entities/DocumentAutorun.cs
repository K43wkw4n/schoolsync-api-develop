using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSync.DAL.Entities
{
    public class DocumentAutorun
    {
        [Key]
        public int DocumentAutorunID { get; set; }
        [MaxLength(4)]
        public string Years { get; set; } = null!;
        [MaxLength(2)]
        public string Months { get; set; } = null!;
        public int? DocumentTypeCode { get; set; }
        // public DateTime CreatedDate { get; set; }
        // public string IsUsed { get; set; } = null!;


    }
}