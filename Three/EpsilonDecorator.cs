namespace Three
{
    internal class EpsilonDecorator : ITemplateGenerator
    {
        private readonly ITemplateGenerator gammaGenerator;

        public EpsilonDecorator(ITemplateGenerator gammaGenerator) => this.gammaGenerator = gammaGenerator;

        public BinaryNumber GetTemplate() => !gammaGenerator.GetTemplate();
    }
}
