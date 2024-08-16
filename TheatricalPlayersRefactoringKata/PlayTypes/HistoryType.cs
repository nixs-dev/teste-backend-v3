namespace TheatricalPlayersRefactoringKata.PlayTypes;


class HistoryType : AbstractPlay
{
    public HistoryType(string name, int lines, int audience) : base(name, lines, audience) {}

    public override float GetAmountOwned()
    {
        ComedyType comedyAmount = new ComedyType(null, this.Lines, this.Audience);
        TragedyType tragedyAmount = new TragedyType(null, this.Lines, this.Audience);

        return comedyAmount.GetAmountOwned() + tragedyAmount.GetAmountOwned();
    }
}
