using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TheatricalPlayersRefactoringKata.Models;

[Table("performances")]
public class Performance
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Play")]
    public int PlayId { get; set; }

    [JsonIgnore]
    [Required]
    public Play Play { get; set; }

    [ForeignKey("Invoice")]
    public int InvoiceId { get; set; }

    [JsonIgnore]
    [Required]
    public Invoice Invoice { get; set; }

    [Required]
    public int Audience { get; set; }
}