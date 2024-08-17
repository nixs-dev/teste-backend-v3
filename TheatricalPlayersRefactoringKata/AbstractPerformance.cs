namespace TheatricalPlayersRefactoringKata;

public abstract class AbstractPerformance
{
    protected Play _play;
    protected int _audience;

    public Play Play { get => _play; set => _play = value; }
    public int Audience { get => _audience; set => _audience = value; }

    public AbstractPerformance(Play play, int audience)
    {
        this._play = play;
        this._audience = audience;
    }

    public abstract float GetAmountOwned();

    public virtual int GetCredits()
    {
        return this._audience > 30 ? this._audience - 30 : 0;
    }
}
