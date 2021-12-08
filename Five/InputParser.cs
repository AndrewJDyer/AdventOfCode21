namespace Five;

internal class InputParser
{
    private readonly string filePath;

    public InputParser(string filePath) => this.filePath = filePath;

    public IEnumerable<HydrothermalVent> Parse()
        => File.ReadAllLines(filePath)
            .Where(l => !String.IsNullOrWhiteSpace(l))
            .Select(ParseLine);

    private static HydrothermalVent ParseLine(string line)
    {
        if (String.IsNullOrWhiteSpace(line))
            throw new InvalidOperationException("Unparsable (empty) line");

        var endPointStrings = line.Split(" -> ");
        if (endPointStrings.Length != 2)
            throw new InvalidOperationException($"Unparsable line (cannot parse endpoints): {line}");

        var start = ParseEndPoint(endPointStrings[0]);
        var end = ParseEndPoint(endPointStrings[1]);
        return new(start, end);
    }

    private static Coordinate ParseEndPoint(string endPointString)
    {
        var values = endPointString.Split(',');
        if (values.Length != 2)
            throw new InvalidOperationException($"Unparsable coordinate {endPointString}");

        if (!int.TryParse(values[0], out var x) || !int.TryParse(values[1], out var y))
            throw new InvalidOperationException($"Unparsable coordinate {endPointString}");

        return new Coordinate(x, y);
    }
}
