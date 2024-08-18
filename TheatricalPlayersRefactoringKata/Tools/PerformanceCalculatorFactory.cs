using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Tools.PerformanceTypes;

namespace TheatricalPlayersRefactoringKata.Tools;

public class PerformanceCalculatorFactory
{
    private static Dictionary<string, Func<Performance, object>> allowedTypes = new Dictionary<string, Func<Performance, object>> {
        { "comedy", (performance) => new ComedyType(performance) },
        { "tragedy", (performance) => new TragedyType(performance) },
        { "history", (performance) => new HistoryType(performance) },
    };

    public static AbstractPerformanceCalculator? Build(Performance performance)
    {
        if (allowedTypes.TryGetValue(performance.Play.Type, out Func<Performance, object>? factory))
        {
            return (AbstractPerformanceCalculator)factory(performance);
        }

        return null;
    }
}
