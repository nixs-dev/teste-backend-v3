using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Tools.PerformanceTypes;


public class ComedyType : AbstractPerformanceCalculator
{
    public ComedyType(Performance performance) : base(performance) { }

    public override float GetAmountOwned()
    {
        float amount =  Performance.Play.BaseValue + Performance.Audience * 3;

        if (Performance.Audience > 20) amount += 100 + (Performance.Audience - 20) * 5;

        return amount;
    }

    public override int GetCredits()
    {
        return base.GetCredits() + (int)Math.Floor((float)Performance.Audience / 5);
    }
}
