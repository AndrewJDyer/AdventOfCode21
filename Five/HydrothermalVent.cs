namespace Five;

internal class HydrothermalVent
{
    private readonly Coordinate start;
    private readonly Coordinate end;

    public bool IsOrthogonal => start.X == end.X || start.Y == end.Y;

    public HydrothermalVent(Coordinate start, Coordinate end)
    {
        this.start = start;
        this.end = end;
    }

    public static IEnumerable<Coordinate> operator |(HydrothermalVent a, HydrothermalVent b)
    {
        foreach (var coordinate in a.EnumerateCoordinates())
            yield return coordinate;
        foreach (var coordinate in b.EnumerateCoordinates())
            yield return coordinate;
    }

    public IEnumerable<Coordinate> EnumerateCoordinates()
    {
        for (var coordinate = start; coordinate != end; coordinate = coordinate.StepTowards(end))
            yield return coordinate;

        if (start != end)
            yield return end;
    }
}
