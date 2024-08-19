using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Core;

namespace TheatricalPlayersRefactoringKata.Core.PerformanceTypes;

public class TragedyType : AbstractPerformanceCalculator
{
    public TragedyType(Performance performance) : base(performance) { }

    public override float GetAmountOwned()
    {
        if (Performance.Audience <= 30) return Performance.Play.BaseValue;

        return Performance.Play.BaseValue + (Performance.Audience - 30) * 10;
    }
}
