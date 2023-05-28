using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolSync.DAL.Entities;
public class Position
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(2)]
    public string PositionCode { get; set; } = null!;
    [MaxLength(80)]
    [Required]
    public string PositionName { get; set; } = null!;
    [Required]
    public DateTime CreateDate { get; set; }
    [MaxLength(1)]
    [Required]
    public string IsUsed { get; set; } = null!;
    public int? DivisionCode { get; set; } 
};