using System.Xml.Linq;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Tools.PrinterTypes;

public class XMLPrinter : AbstractStatementPrinter
{
    public override string Print(Invoice invoice)
    {
        List<XElement> items = new List<XElement> { };
        float totalAmount = 0;
        int totalCredits = 0;

        foreach (Performance performance in invoice.Performances)
        {
            AbstractPerformanceCalculator? performanceCalculator = PerformanceCalculatorFactory.Build(performance) ?? throw new Exception("Gênero inválido");

            XElement element = new XElement("Item",
                new XElement("AmountOwed", performanceCalculator.GetAmountOwned()),
                new XElement("EarnedCredits", performanceCalculator.GetCredits()),
                new XElement("Seats", performance.Audience)
            );

            items.Add(element);

            totalAmount += performanceCalculator.GetAmountOwned();
            totalCredits += performanceCalculator.GetCredits();
        }

        XDocument xmlOutput = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("Statement",
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                new XElement("Customer", invoice.Customer),
                new XElement("Items", items),
                new XElement("AmountOwed", totalAmount),
                new XElement("EarnedCredits", totalCredits)
            )
        );
       

        return xmlOutput.ToString();
    }
}
