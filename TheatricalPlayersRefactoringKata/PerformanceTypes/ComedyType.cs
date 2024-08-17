using System;

namespace TheatricalPlayersRefactoringKata.PerformanceTypes;


public class ComedyType : AbstractPerformance
{
    public ComedyType(Play play, int audience) : base(play, audience) { }

    public override float GetAmountOwned()
    {
        float amount = this._play.BaseValue + this._audience * 3;

        if (this._audience > 20) amount += 100 + (this._audience - 20) * 5;

        return amount;
    }

    public override int GetCredits()
    {
        return base.GetCredits() + (int) Math.Floor((float) this._audience/5);
    }
}
