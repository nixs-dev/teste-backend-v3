using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;

public class Invoice
{
    private string _customer;
    private List<AbstractPerformance> _performances;

    public string Customer { get => _customer; set => _customer = value; }
    public List<AbstractPerformance> Performances { get => _performances; set => _performances = value; }

    public Invoice(string customer, List<AbstractPerformance> performances)
    {
        this._customer = customer;
        this._performances = performances;
    }

}
