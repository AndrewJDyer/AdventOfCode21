namespace Eight.Parser;

public class Parser
{
    private readonly string filePath;

    public Parser(string filePath) => this.filePath = filePath;

    public IEnumerable<Display> Parse() => GetNonEmptyLines().Select(ParseLine);

    private IEnumerable<string> GetNonEmptyLines() => File.ReadAllLines(filePath).Where(IsNonEmpty);

    private Display ParseLine(string line)
    {
        var split = line.Split('|');
        if (split.Length != 2)
            throw new InvalidOperationException($"Unparsable line {line}");

        return new(GetWords(split[0]), GetWords(split[1]));
    }

    private static IEnumerable<string> GetWords(string wordCollection) => wordCollection.Split(' ').Where(IsNonEmpty);

    private static bool IsNonEmpty(string line) => !String.IsNullOrWhiteSpace(line);
}
