namespace TheatricalPlayersRefactoringKata.PerformanceTypes;

public class TragedyType : AbstractPerformance
{
    public TragedyType(Play play, int audience) : base(play, audience) {}

    public override float GetAmountOwned()
    {
        if (this._audience <= 30) return this._play.BaseValue;

        return this._play.BaseValue + (this._audience - 30) * 10;
    }
}
