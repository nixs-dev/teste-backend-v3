using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Tools.PerformanceTypes;

public class HistoryType : AbstractPerformanceCalculator
{
    public HistoryType(Performance performance) : base(performance) { }

    public override float GetAmountOwned()
    {
        Play comedyPlay = new Play();
        comedyPlay.Lines = Performance.Play.Lines;
        comedyPlay.Type = "comedy";

        Play tragedyPlay = new Play();
        tragedyPlay.Lines = Performance.Play.Lines;
        tragedyPlay.Type = "tragedy";

        Performance comedyPerformance = new Performance();
        comedyPerformance.Invoice = Performance.Invoice;
        comedyPerformance.Play = comedyPlay;
        comedyPerformance.Audience = Performance.Audience;

        Performance tragedyPerformance = new Performance();
        tragedyPerformance.Invoice = Performance.Invoice;
        tragedyPerformance.Play = tragedyPlay;
        tragedyPerformance.Audience = Performance.Audience;

        AbstractPerformanceCalculator? comedyCalculator = PerformanceCalculatorFactory.Build(comedyPerformance);
        AbstractPerformanceCalculator? tragedyCalculator = PerformanceCalculatorFactory.Build(tragedyPerformance);

        if (comedyCalculator == null || tragedyCalculator == null)
        {
            throw new Exception("Gênero inválido");
        }

        return comedyCalculator.GetAmountOwned() + tragedyCalculator.GetAmountOwned();
    }
}
