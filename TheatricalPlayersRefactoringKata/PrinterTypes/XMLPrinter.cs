using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TheatricalPlayersRefactoringKata.PrinterTypes;

 public class XMLPrinter : AbstractStatementPrinter
{
    public override string Print(Invoice invoice)
    {
        List<XElement> items = new List<XElement> { };
        float totalAmount = 0;
        int totalCredits = 0;

        foreach (AbstractPerformance performance in invoice.Performances) {
            XElement element = new XElement("Item",
                new XElement("AmountOwed", performance.GetAmountOwned()),
                new XElement("EarnedCredits", performance.GetCredits()),
                new XElement("Seats", performance.Audience)
            );

            items.Add(element);

            totalAmount += performance.GetAmountOwned();
            totalCredits += performance.GetCredits();
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
