namespace Five;

internal class IntersectionCounter
{
    private readonly IEnumerable<HydrothermalVent> vents;

    public IntersectionCounter(IEnumerable<HydrothermalVent> vents) => this.vents = vents;

    public int CountIntersections() => GetIntersections().Count();

    private IEnumerable<Coordinate> GetIntersections() => GetCumulativeCoordinates().GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key);

    private IEnumerable<Coordinate> GetCumulativeCoordinates() => vents.Where(v => v.IsOrthogonal).SelectMany(v => v.EnumerateCoordinates());
}
