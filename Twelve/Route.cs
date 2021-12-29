namespace Twelve;

internal class Route
{
    private readonly List<Cave> route = new();
    private bool usedSmallCaveDoubleVisit = false;

    public Route(Cave start) => route.Add(start);

    private Route(IReadOnlyCollection<Cave> caves, bool usedSmallCaveDoubleVisit)
    {
        route.AddRange(caves);
        this.usedSmallCaveDoubleVisit = usedSmallCaveDoubleVisit;
    }

    public Route Copy() => new(route, usedSmallCaveDoubleVisit);

    public void AddCave(Cave cave)
    {
        if (!IsStepValid(cave))
            throw new InvalidOperationException($"Already visited small cave {cave.Name}");

        if (!usedSmallCaveDoubleVisit && cave.IsSmall && route.Contains(cave))
            usedSmallCaveDoubleVisit = true;
        route.Add(cave);
    }

    public bool IsStepValid(Cave cave) => cave.IsBig || CanVisitSmallCave(cave);

    private bool CanVisitSmallCave(Cave smallCave)
    {
        if (!route.Contains(smallCave))
            return true;
        if (smallCave.IsStart || smallCave.IsEnd)
            return false;
        return !usedSmallCaveDoubleVisit;
    }
}
