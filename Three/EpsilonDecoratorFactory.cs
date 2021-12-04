namespace Three
{
    internal class EpsilonDecoratorFactory : ITemplateGeneratorFactory
    {
        public ITemplateGenerator Create(IEnumerable<BinaryNumber> candidates)
            => new EpsilonDecorator(new GammaCalculatorFactory().Create(candidates));
    }
}
