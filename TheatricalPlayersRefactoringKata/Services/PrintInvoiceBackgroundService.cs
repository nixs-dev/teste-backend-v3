namespace TheatricalPlayersRefactoringKata.Services;

public class PrintInvoiceBackgroundService : BackgroundService
{
    private readonly PrintInvoiceService _printInvoiceService;

    public PrintInvoiceBackgroundService(PrintInvoiceService printInvoiceService)
    {
        _printInvoiceService = printInvoiceService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _printInvoiceService.ProcessQueueAsync(stoppingToken);
    }
}