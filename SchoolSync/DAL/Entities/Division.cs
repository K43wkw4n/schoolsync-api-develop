using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSync.DAL.Entities;
public class Division
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto key
	[MaxLength(2)]
	public int? DivisionCode {get; set;}
	[MaxLength(80)]
	[Required]
	public string DivisionName {get; set;} = null!;
	[Required]
	public DateTime CreatedDate {get; set;}
	[DefaultValue(true)]
	public bool IsUsed {get; set;}
}
