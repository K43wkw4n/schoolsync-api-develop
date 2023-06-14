using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSync.DAL.Entities
{
    public class Employees
    {
        [Key]
        public int      EmpCode     { get; set; }
        [MaxLength(1)]
        public string   InitialCode { get; set; } = null!;
        [MaxLength(50)]
        public string   Firstname   { get; set; } = null!;
        [MaxLength(50)]
        public string   Lastname    { get; set; } = null!;
        [MaxLength(10)]
        public string   MobilePhone { get; set; } = null!;
        [MaxLength(50)]
        public string   Email       { get; set; } = null!;
        [MaxLength(50)]
        public string   Address     { get; set; } = null!;
        [MaxLength(6)]
        public string   Subdistrict { get; set; } = null!;
        [MaxLength(4)]
        public string   District    { get; set; } = null!;
        [MaxLength(2)]
        public string   Province    { get; set; } = null!;
        [MaxLength(5)]
        public string   Postcode    { get; set; } = null!;
        [MaxLength(50)]
        public string   Username    { get; set; } = null!;
        [MaxLength(50)]
        public string   Password    { get; set; } = null!;
        public string   CreatedDate { get; set; } = null!;
        [MaxLength(1)]
        public string   IsUsed      { get; set; } = null!;
        public int?     DivisionCode { get; set; }
    }
}