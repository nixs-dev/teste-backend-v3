using TheatricalPlayersRefactoringKata.Core;

namespace TheatricalPlayersRefactoringKata.Services.Interfaces;

public interface IPrintInvoiceQueue
{
    Task EnqueuePrintInvoiceAsync(AbstractStatementPrinter printer);
    Task<AbstractStatementPrinter> DequeuePrintInvoiceAsync();
}