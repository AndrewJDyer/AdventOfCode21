namespace Twelve;

internal class Route
{
    private readonly List<Cave> route = new();

    public Route(Cave start) => route.Add(start);

    private Route(IReadOnlyCollection<Cave> caves) => route.AddRange(caves);

    public Route Copy() => new(route);

    public void AddCave(Cave cave)
    {
        if (cave.IsSmall && route.Contains(cave))
            throw new InvalidOperationException($"Already visited small cave {cave.Name}");

        route.Add(cave);
    }

    public bool HaveVisited(Cave cave) => route.Contains(cave);
}
