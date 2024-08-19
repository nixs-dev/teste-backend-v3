namespace TheatricalPlayersRefactoringKata.DTOs;

public class InvoiceCreationRequestDTO
{
    public string Customer { get; set; } = string.Empty;
    public List<PerformanceDTO> Performances { get; set; } = new List<PerformanceDTO>();
}