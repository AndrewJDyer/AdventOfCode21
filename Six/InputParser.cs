namespace Six;

internal class InputParser
{
    private readonly string path;

    public InputParser(string path) => this.path = path;

    public IEnumerable<Lanternfish> Parse()
    {
        var line = File.ReadAllText(path);
        return line.Split(',').Select(ParseNumber).Select(x => new Lanternfish(x));
    }

    private static int ParseNumber(string numString) => int.Parse(numString);
}
