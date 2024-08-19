using System.Collections.Concurrent;
using TheatricalPlayersRefactoringKata.Core;
using TheatricalPlayersRefactoringKata.Services.Interfaces;

namespace TheatricalPlayersRefactoringKata.Services;

public class PrintInvoiceQueue : IPrintInvoiceQueue
{
    private readonly ConcurrentQueue<AbstractStatementPrinter> _queue = new ConcurrentQueue<AbstractStatementPrinter>();

    public Task EnqueuePrintInvoiceAsync(AbstractStatementPrinter printer)
    {
        _queue.Enqueue(printer);

        return Task.CompletedTask;
    }

    public Task<AbstractStatementPrinter> DequeuePrintInvoiceAsync()
    {
        _queue.TryDequeue(out var printer);

        return Task.FromResult(printer);
    }
}