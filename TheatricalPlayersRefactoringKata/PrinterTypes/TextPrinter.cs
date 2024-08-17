using System.Globalization;
using System;


namespace TheatricalPlayersRefactoringKata.PrinterTypes;

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
            result += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", performance.Play.Name, performance.GetAmountOwned(), performance.Audience);
            totalAmount += performance.GetAmountOwned();
            volumeCredits += performance.GetCredits();
        }

        result += String.Format(cultureInfo, "Amount owed is {0:C}\n", totalAmount);
        result += String.Format("You earned {0} credits\n", volumeCredits);
        return result;
    }
}