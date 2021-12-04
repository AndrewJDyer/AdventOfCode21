namespace Three;

internal class RatingCalculator
{
    private readonly Report report;
    private readonly ITemplateGeneratorFactory templateGeneratorFactory;

    public RatingCalculator(Report report, ITemplateGeneratorFactory templateGeneratorFactory)
    {
        this.report = report;
        this.templateGeneratorFactory = templateGeneratorFactory;
    }

    public BinaryNumber Calculate()
    {
        IEnumerable<BinaryNumber> candidates = report;
        for (int i = 0; i < report.Length; i++)
        {
            var filter = new RatingFilter(candidates, templateGeneratorFactory);
            candidates = filter.Filter(i);
            switch (candidates.Count())
            {
                case 0: throw new InvalidOperationException("No matching number");
                case 1: return candidates.Single();
                default: continue;
            }
        }

        throw new InvalidOperationException("No matching number");
    }
}
