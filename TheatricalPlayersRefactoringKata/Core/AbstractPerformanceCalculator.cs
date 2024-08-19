using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Core;

public abstract class AbstractPerformanceCalculator
{
    private Performance _performance;

    public Performance Performance { get => _performance; set => _performance = value; }

    public AbstractPerformanceCalculator(Performance performance)
    {
        _performance = performance;
    }

    public abstract float GetAmountOwned();

    public virtual int GetCredits()
    {
        return this.Performance.Audience > 30 ? this.Performance.Audience - 30 : 0;
    }
}
