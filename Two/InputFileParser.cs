namespace Two;

internal class InputFileParser
{
    private readonly string path;

    public InputFileParser(string path) => this.path = path;

    public IEnumerable<Command> Parse() => ReadLines().Select(ParseLine);

    private IEnumerable<string> ReadLines() => File.ReadAllLines(path);

    private static Command ParseLine(string line) => new LineParser(line).Parse();
}
