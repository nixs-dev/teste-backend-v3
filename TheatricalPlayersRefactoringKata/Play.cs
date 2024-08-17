namespace TheatricalPlayersRefactoringKata;

public class Play
{
    private string _name;
    private int _lines;
    private string _type;
    private float _baseValue;

    public string Name { get => _name; set => _name = value; }
    public int Lines { get => _lines; set => _lines = value > 4000 ? 4000 : value < 1000 ? 1000 : value; }
    public string Type { get => _type; set => _type = value; }
    public float BaseValue { get => _baseValue; set => _baseValue = value; }

    public Play(string name, int lines, string type) {
        this._name = name;
        this.Lines = lines;
        this._type = type;
        this._baseValue = (float) this.Lines / 10f;
    }
}
