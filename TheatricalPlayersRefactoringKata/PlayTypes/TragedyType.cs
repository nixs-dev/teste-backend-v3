namespace TheatricalPlayersRefactoringKata.PlayTypes;


class TragedyType : AbstractPlay
{
    public TragedyType(string name, int lines, int audience) : base(name, lines, audience) {}

    public override float GetAmountOwned()
    {
        if (this.Audience <= 30) return _baseValue;

        return _baseValue + (this.Audience - 30) * 10;
    }
}
