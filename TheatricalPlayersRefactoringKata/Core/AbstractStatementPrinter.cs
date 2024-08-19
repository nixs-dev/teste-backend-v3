namespace TheatricalPlayersRefactoringKata.Core;

using TheatricalPlayersRefactoringKata.Models;

public abstract class AbstractStatementPrinter
{
    public Invoice Invoice { get; set; }
    public abstract string Extension { get; }


    public AbstractStatementPrinter(Invoice invoice)
    {
        this.Invoice = invoice;
    }

    public abstract string Print();
}
