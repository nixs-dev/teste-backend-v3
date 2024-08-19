using TheatricalPlayersRefactoringKata.Core.PrinterTypes;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Core;

public class StatementPrinterFactory
{
    private static readonly Dictionary<string, Func<Invoice, object>> allowedTypes = new Dictionary<string, Func<Invoice, object>> {
        { "text", (invoice) => new TextPrinter(invoice) },
        { "xml", (invoice) => new XMLPrinter(invoice) },
    };

    public static AbstractStatementPrinter? Build(Invoice invoice, String format)
    {
        if (allowedTypes.TryGetValue(format, out Func<Invoice, object>? factory))
        {
            return (AbstractStatementPrinter) factory(invoice);
        }

        return null;
    }
}
