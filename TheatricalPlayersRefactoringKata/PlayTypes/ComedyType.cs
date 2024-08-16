using System;

namespace TheatricalPlayersRefactoringKata.PlayTypes;


class ComedyType : AbstractPlay
{
    public ComedyType(string name, int lines, int audience) : base(name, lines, audience) {}

    public override float GetAmountOwned()
    {
        float amount = _baseValue + this.Audience * 3;

        if (this.Audience > 20) amount += 100 + (this.Audience - 20) * 5;

        return amount;
    }

    public override int GetCredits()
    {
        return base.GetCredits() + (int) Math.Floor((float) this.Audience/5);
    }
}
