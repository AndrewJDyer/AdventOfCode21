namespace Three;

internal class GammaCalculatorFactory : ITemplateGeneratorFactory
{
    public ITemplateGenerator Create(IEnumerable<BinaryNumber> candidates) => new GammaCalculator(candidates);
}
