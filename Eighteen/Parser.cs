namespace Eighteen;

internal class Parser
{
    private readonly string filePath;

    public Parser(string filePath) => this.filePath = filePath;

    public IEnumerable<SnailfishPairElement> Parse() => File.ReadAllLines(filePath).Select(ParseLine);

    private SnailfishPairElement ParseLine(string line) => new LineParser(line).Parse();
}
