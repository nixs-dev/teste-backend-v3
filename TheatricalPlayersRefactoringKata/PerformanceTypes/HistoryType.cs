namespace TheatricalPlayersRefactoringKata.PerformanceTypes;


public class HistoryType : AbstractPerformance
{
    public HistoryType(Play play, int audience) : base(play, audience) { }

    public override float GetAmountOwned()
    {
        AbstractPerformance comedyAmount = PerformanceFactory.Build(new Play(null, this._play.Lines, "comedy"), this.Audience);
        AbstractPerformance tragedyAmount = PerformanceFactory.Build(new Play(null, this._play.Lines, "tragedy"), this.Audience);

        return comedyAmount.GetAmountOwned() + tragedyAmount.GetAmountOwned();
    }
}
