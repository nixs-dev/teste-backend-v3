namespace TheatricalPlayersRefactoringKata.DTOs;

public class InvoiceUpdateRequestDTO
{
    public int Id { get; set; }
    public string Customer { get; set; } = string.Empty;
}