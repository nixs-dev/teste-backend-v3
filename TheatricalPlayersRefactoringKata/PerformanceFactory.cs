using System;
using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.PerformanceTypes;

namespace TheatricalPlayersRefactoringKata;

public class PerformanceFactory
{
    private static Dictionary<string, Func<Play, int, object>> allowedTypes = new Dictionary<string, Func<Play, int, object>> {
        { "comedy", (play, audience) => new ComedyType(play, audience) },
        { "tragedy", (play, audience) => new TragedyType(play, audience) },
        { "history", (play, audience) => new HistoryType(play, audience) },
    };

    public static AbstractPerformance? Build(Play play, int audience)
    {
        if (allowedTypes.TryGetValue(play.Type, out Func<Play, int, object> factory))
        {
            return (AbstractPerformance) factory(play, audience);
        }

        return null;
    }
}
