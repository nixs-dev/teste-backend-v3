using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using TheatricalPlayersRefactoringKata.PrinterTypes;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        Dictionary<string, Play> plays = new Dictionary<string, Play>()
        {
            { "hamlet", new Play("Hamlet", 4024, "tragedy") },
            { "as-you-like-it", new Play("As You Like It", 2670, "comedy") },
            { "othello", new Play("Othello", 3560, "tragedy") }
        };    

        Invoice invoice = new Invoice(
            "BigCo",
            new List<AbstractPerformance>
            {
                PerformanceFactory.Build(plays["hamlet"], 55),
                PerformanceFactory.Build(plays["as-you-like-it"], 35),
                PerformanceFactory.Build(plays["othello"], 40)
            }
        );

        AbstractStatementPrinter statementPrinter = new TextPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        Dictionary<string, Play> plays = new Dictionary<string, Play>()
        {
            { "hamlet", new Play("Hamlet", 4024, "tragedy") },
            { "as-you-like-it", new Play("As You Like It", 2670, "comedy") },
            { "othello", new Play("Othello", 3560, "tragedy") },
            { "henry-v", new Play("Henry V", 3227, "history") },
            { "king-john", new Play("King John", 2648, "history") }
        };

        Invoice invoice = new Invoice(
            "BigCo",
            new List<AbstractPerformance>
            {
                PerformanceFactory.Build(plays["hamlet"], 55),
                PerformanceFactory.Build(plays["as-you-like-it"], 35),
                PerformanceFactory.Build(plays["othello"], 40),
                PerformanceFactory.Build(plays["henry-v"], 20),
                PerformanceFactory.Build(plays["king-john"], 39),
                PerformanceFactory.Build(plays["henry-v"], 20)
            }
        );

        AbstractStatementPrinter statementPrinter = new TextPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestXmlStatementExample()
    {
        Dictionary<string, Play> plays = new Dictionary<string, Play>()
        {
            { "hamlet", new Play("Hamlet", 4024, "tragedy") },
            { "as-you-like-it", new Play("As You Like It", 2670, "comedy") },
            { "othello", new Play("Othello", 3560, "tragedy") },
            { "henry-v", new Play("Henry V", 3227, "history") },
            { "king-john", new Play("King John", 2648, "history") }
        };

        Invoice invoice = new Invoice(
            "BigCo",
            new List<AbstractPerformance>
            {
                PerformanceFactory.Build(plays["hamlet"], 55),
                PerformanceFactory.Build(plays["as-you-like-it"], 35),
                PerformanceFactory.Build(plays["othello"], 40),
                PerformanceFactory.Build(plays["henry-v"], 20),
                PerformanceFactory.Build(plays["king-john"], 39),
                PerformanceFactory.Build(plays["henry-v"], 20)
            }
        );

        AbstractStatementPrinter statementPrinter = new XMLPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }
}
