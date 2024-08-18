using System.Globalization;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Tools.PrinterTypes;

public class TextPrinter : AbstractStatementPrinter
{
    public override string Print(Invoice invoice)
    {
        float totalAmount = 0;
        int volumeCredits = 0;
        string result = string.Format("Statement for {0}\n", invoice.Customer);
        CultureInfo cultureInfo = new CultureInfo("en-US");

        foreach (var performance in invoice.Performances)
        {
            AbstractPerformanceCalculator? performanceCalculator = PerformanceCalculatorFactory.Build(performance) ?? throw new Exception("Gênero inválido");

            result += string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", performance.Play.Name, performanceCalculator.GetAmountOwned(), performance.Audience);
            totalAmount += performanceCalculator.GetAmountOwned();
            volumeCredits += performanceCalculator.GetCredits();
        }

        result += string.Format(cultureInfo, "Amount owed is {0:C}\n", totalAmount);
        result += string.Format("You earned {0} credits\n", volumeCredits);

        return result;
    }
}