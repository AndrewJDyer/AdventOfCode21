namespace Two;

internal class LineParser
{
    private readonly string line;

    public LineParser(string line) => this.line = line;

    public Command Parse()
    {
        var (directionString, distanceString) = Split();
        var distance = ParseDistance(distanceString);
        var direction = ParseDirection(directionString);

        return new(direction, distance);
    }

    private static int ParseDistance(string distanceString)
        => int.TryParse(distanceString, out var distance) ?
        distance :
        throw new InvalidOperationException($"Unparsable distance {distanceString}");

    private static Direction ParseDirection(string directionString) => directionString switch
    {
        "forward" => Direction.Forward,
        "up" => Direction.Up,
        "down" => Direction.Down,
        _ => throw new InvalidOperationException($"Unparsable direction {directionString}")
    };

    private (string DirectionString, string DistanceString) Split()
    {
        var parts = line.Split(' ');
        if (parts.Length != 2)
            throw new InvalidOperationException($"Unparsable line {line}");

        return (parts[0], parts[1]);
    }
}
