using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Tools;
using TheatricalPlayersRefactoringKata.Tools.PrinterTypes;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        Invoice invoice = new Invoice();
        invoice.Customer = "BigCo";

        Play hamletPlay = new Play();
        hamletPlay.Name = "Hamlet";
        hamletPlay.Lines = 4024;
        hamletPlay.Type = "tragedy";

        Play asYouLikePlay = new Play();
        asYouLikePlay.Name = "As You Like It";
        asYouLikePlay.Lines = 2670;
        asYouLikePlay.Type = "comedy";

        Play othelloPlay = new Play();
        othelloPlay.Name = "Othello";
        othelloPlay.Lines = 3560;
        othelloPlay.Type = "tragedy";

        Performance hamletPerformance = new Performance();
        hamletPerformance.Invoice = invoice;
        hamletPerformance.Play = hamletPlay;
        hamletPerformance.Audience = 55;


        Performance asYouLikePerformance = new Performance();
        asYouLikePerformance.Invoice = invoice;
        asYouLikePerformance.Play = asYouLikePlay;
        asYouLikePerformance.Audience = 35;

        Performance othelloPerformance = new Performance();
        othelloPerformance.Invoice = invoice;
        othelloPerformance.Play = othelloPlay;
        othelloPerformance.Audience = 40;

        invoice.Performances = new List<Performance> { hamletPerformance, asYouLikePerformance, othelloPerformance };


        AbstractStatementPrinter statementPrinter = new TextPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        Invoice invoice = new Invoice();
        invoice.Customer = "BigCo";

        Play hamletPlay = new Play();
        hamletPlay.Name = "Hamlet";
        hamletPlay.Lines = 4024;
        hamletPlay.Type = "tragedy";

        Play asYouLikeItPlay = new Play();
        asYouLikeItPlay.Name = "As You Like It";
        asYouLikeItPlay.Lines = 2670;
        asYouLikeItPlay.Type = "comedy";

        Play othelloPlay = new Play();
        othelloPlay.Name = "Othello";
        othelloPlay.Lines = 3560;
        othelloPlay.Type = "tragedy";

        Play henryVPlay = new Play();
        henryVPlay.Name = "Henry V";
        henryVPlay.Lines = 3227;
        henryVPlay.Type = "history";

        Play kingJohnPlay = new Play();
        kingJohnPlay.Name = "King John";
        kingJohnPlay.Lines = 2648;
        kingJohnPlay.Type = "history";

        Performance hamletPerformance = new Performance();
        hamletPerformance.Invoice = invoice;
        hamletPerformance.Play = hamletPlay;
        hamletPerformance.Audience = 55;

        Performance asYouLikeItPerformance = new Performance();
        asYouLikeItPerformance.Invoice = invoice;
        asYouLikeItPerformance.Play = asYouLikeItPlay;
        asYouLikeItPerformance.Audience = 35;

        Performance othelloPerformance = new Performance();
        othelloPerformance.Invoice = invoice;
        othelloPerformance.Play = othelloPlay;
        othelloPerformance.Audience = 40;

        Performance henryVPerformance = new Performance();
        henryVPerformance.Invoice = invoice;
        henryVPerformance.Play = henryVPlay;
        henryVPerformance.Audience = 20;

        Performance kingJohnPerformance = new Performance();
        kingJohnPerformance.Invoice = invoice;
        kingJohnPerformance.Play = kingJohnPlay;
        kingJohnPerformance.Audience = 39;

        Performance henryVPerformance2 = new Performance();
        henryVPerformance2.Invoice = invoice;
        henryVPerformance2.Play = henryVPlay;
        henryVPerformance2.Audience = 20;

        invoice.Performances = new List<Performance>
        {
            hamletPerformance,
            asYouLikeItPerformance,
            othelloPerformance,
            henryVPerformance,
            kingJohnPerformance,
            henryVPerformance2
        };
        

        AbstractStatementPrinter statementPrinter = new TextPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestXmlStatementExample()
    {
        Invoice invoice = new Invoice();
        invoice.Customer = "BigCo";

        Play hamletPlay = new Play();
        hamletPlay.Name = "Hamlet";
        hamletPlay.Lines = 4024;
        hamletPlay.Type = "tragedy";

        Play asYouLikeItPlay = new Play();
        asYouLikeItPlay.Name = "As You Like It";
        asYouLikeItPlay.Lines = 2670;
        asYouLikeItPlay.Type = "comedy";

        Play othelloPlay = new Play();
        othelloPlay.Name = "Othello";
        othelloPlay.Lines = 3560;
        othelloPlay.Type = "tragedy";

        Play henryVPlay = new Play();
        henryVPlay.Name = "Henry V";
        henryVPlay.Lines = 3227;
        henryVPlay.Type = "history";

        Play kingJohnPlay = new Play();
        kingJohnPlay.Name = "King John";
        kingJohnPlay.Lines = 2648;
        kingJohnPlay.Type = "history";

        Performance hamletPerformance = new Performance();
        hamletPerformance.Invoice = invoice;
        hamletPerformance.Play = hamletPlay;
        hamletPerformance.Audience = 55;

        Performance asYouLikeItPerformance = new Performance();
        asYouLikeItPerformance.Invoice = invoice;
        asYouLikeItPerformance.Play = asYouLikeItPlay;
        asYouLikeItPerformance.Audience = 35;

        Performance othelloPerformance = new Performance();
        othelloPerformance.Invoice = invoice;
        othelloPerformance.Play = othelloPlay;
        othelloPerformance.Audience = 40;

        Performance henryVPerformance = new Performance();
        henryVPerformance.Invoice = invoice;
        henryVPerformance.Play = henryVPlay;
        henryVPerformance.Audience = 20;

        Performance kingJohnPerformance = new Performance();
        kingJohnPerformance.Invoice = invoice;
        kingJohnPerformance.Play = kingJohnPlay;
        kingJohnPerformance.Audience = 39;

        Performance henryVPerformance2 = new Performance();
        henryVPerformance2.Invoice = invoice;
        henryVPerformance2.Play = henryVPlay;
        henryVPerformance2.Audience = 20;

        invoice.Performances = new List<Performance>
        {
            hamletPerformance,
            asYouLikeItPerformance,
            othelloPerformance,
            henryVPerformance,
            kingJohnPerformance,
            henryVPerformance2
        };

        AbstractStatementPrinter statementPrinter = new XMLPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }
}
