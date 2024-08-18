namespace TheatricalPlayersRefactoringKata.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("plays")]
public class Play
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = String.Empty;

    [Required]
    public int Lines { get => _lines; set => _lines = value > 4000 ? 4000 : value < 1000 ? 1000 : value; }

    [Required]
    public string Type { get; set; } = String.Empty;
    public float BaseValue => (float)Lines / 10f;

    private int _lines;
}
