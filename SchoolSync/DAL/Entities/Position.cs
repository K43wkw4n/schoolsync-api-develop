using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolSync.DAL.Entities;
public class Position
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(2)]
    public string PositionCode { get; set; }
    [MaxLength(1)]
    [Required]
    public string PositionName { get; set; } = null!;
    [Required]
    public DateTime CreateDate { get; set; }
    [ForeignKey("Division")]
    [Required]
    public string DivisionCode { get; set; }
    [JsonIgnore]
    public Division Division { get; set; }
    [MaxLength(1)]
    [Required]
    public string IsUsed { get; set; } = null!;
};