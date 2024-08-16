namespace TheatricalPlayersRefactoringKata;

public abstract class AbstractPlay
{
    private string _name;
    private int _lines;
    private int _audience;
    protected float _baseValue;

    public string Name { get => _name; set => _name = value; }
    public int Lines { get => _lines; set => _lines = value > 4000 ? 4000 : value < 1000 ? 1000 : value; }
    public int Audience { get => _audience; set => _audience = value; }

    public AbstractPlay(string name, int lines, int audience) {
        this._name = name;
        this._audience = audience;
        this.Lines = lines;
        this._baseValue = lines / 10;
    }

    public abstract float GetAmountOwned();

    public virtual int GetCredits()
    {
        return this.Audience > 30 ? this.Audience - 30 : 0;
    }
}
