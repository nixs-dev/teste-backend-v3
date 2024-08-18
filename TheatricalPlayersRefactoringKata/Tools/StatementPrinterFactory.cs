using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Tools.PerformanceTypes;
using TheatricalPlayersRefactoringKata.Tools.PrinterTypes;

namespace TheatricalPlayersRefactoringKata.Tools;

public class StatementPrinterFactory
{
    private static Dictionary<string, Func<object>> allowedTypes = new Dictionary<string, Func<object>> {
        { "text", () => new TextPrinter() },
        { "xml", () => new XMLPrinter() },
    };

    public static AbstractStatementPrinter? Build(String format)
    {
        if (allowedTypes.TryGetValue(format, out Func<object>? factory))
        {
            return (AbstractStatementPrinter) factory();
        }

        return null;
    }
}
