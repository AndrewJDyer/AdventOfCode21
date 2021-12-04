namespace Three;

internal class InputFileParser
{
    private readonly string path;

    public InputFileParser(string path) => this.path = path;

    public Report Parse() => new(File.ReadAllLines(path).Select(ParseRow));

    private BinaryNumber ParseRow(string row) => new(row.Select(ParseChar).ToArray());

    private bool ParseChar(char c) => c switch
    {
        '0' => false,
        '1' => true,
        _ => throw new InvalidOperationException($"Unparsable char {c}")
    };
}
