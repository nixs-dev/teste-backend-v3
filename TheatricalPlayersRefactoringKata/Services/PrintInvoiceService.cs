using System.Net.Mail;
using TheatricalPlayersRefactoringKata.Core;
using TheatricalPlayersRefactoringKata.Services.Interfaces;

namespace TheatricalPlayersRefactoringKata.Services;

public class PrintInvoiceService
{
    private readonly string _invoicesPath = Path.Join(Directory.GetCurrentDirectory(), "Storage/Invoices");

    private readonly IPrintInvoiceQueue _printInvoiceQueue;


    public PrintInvoiceService(IPrintInvoiceQueue printInvoiceQueue)
    {
        _printInvoiceQueue = printInvoiceQueue;
    }

    public async Task ProcessQueueAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var printer = await _printInvoiceQueue.DequeuePrintInvoiceAsync();

            if (printer != null)
            {
                string content = printer.Print();
                string path = Path.Combine(this._invoicesPath, $"invoice_{printer.Invoice.Id}.{printer.Extension}");

                File.WriteAllText(path, content);
            }
            else
            {
                await Task.Delay(1000);
            }
        }
    }

    public async Task PrintInvoiceAsync(AbstractStatementPrinter printer)
    {
        await _printInvoiceQueue.EnqueuePrintInvoiceAsync(printer);
    }
}