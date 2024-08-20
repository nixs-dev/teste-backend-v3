using System.ComponentModel.DataAnnotations;

namespace TheatricalPlayersRefactoringKata.DTOs;


public class PlayDTO
{
    public string Name { get; set; } = String.Empty;
    public int Lines { get; set; }

    [RegularExpression("^(comedy|history|tragedy)$", ErrorMessage = "Gênero inválido!")]
    public string Type { get; set; } = String.Empty;
}
