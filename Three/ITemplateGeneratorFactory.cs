namespace Three;

internal interface ITemplateGeneratorFactory
{
    ITemplateGenerator Create(IEnumerable<BinaryNumber> candidates);
}
