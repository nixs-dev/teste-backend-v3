namespace TheatricalPlayersRefactoringKata.DTOs;

public class InvoiceCreationRequest
{
    public string Customer { get; set; } = string.Empty;
    public Dictionary<int, int> Performances { get; set; } = new Dictionary<int, int>();
}