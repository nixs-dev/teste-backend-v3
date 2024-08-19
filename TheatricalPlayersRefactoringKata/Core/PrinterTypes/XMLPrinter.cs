using System.Xml.Linq;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Core.PrinterTypes;

public class XMLPrinter : AbstractStatementPrinter
{
    public override string Extension { get => "xml"; }

    public XMLPrinter(Invoice invoice) : base(invoice) { }

    public override string Print()
    {
        List<XElement> items = new List<XElement> { };
        float totalAmount = 0;
        int totalCredits = 0;
        string xmlDeclaration = "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>";

        foreach (Performance performance in this.Invoice.Performances)
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
            new XElement("Statement",
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                new XElement("Customer", this.Invoice.Customer),
                new XElement("Items", items),
                new XElement("AmountOwed", totalAmount),
                new XElement("EarnedCredits", totalCredits)
            )
        );
       

        return xmlDeclaration + "\n" + xmlOutput.ToString();
    }
}
