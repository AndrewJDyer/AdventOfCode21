namespace Three;

internal class RatingFilter
{
    private readonly IEnumerable<BinaryNumber> candidates;
    private readonly BinaryNumber template;

    public RatingFilter(
        IEnumerable<BinaryNumber> candidates,
        ITemplateGeneratorFactory templateGeneratorFactory)
    {
        this.candidates = candidates;
        template = templateGeneratorFactory.Create(candidates).GetTemplate();
    }

    public IEnumerable<BinaryNumber> Filter(int index) => candidates.Where(x => MatchesTemplate(x, index));

    private bool MatchesTemplate(BinaryNumber number, int index) => number[index] == template[index];
}
