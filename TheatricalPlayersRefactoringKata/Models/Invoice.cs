using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatricalPlayersRefactoringKata.Models;

[Table("invoices")]
public class Invoice
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Customer { get; set; } = String.Empty;

    public ICollection<Performance> Performances { get; set; } = new List<Performance>();
}
