namespace Twelve;

internal class Cave
{
    public const string StartName = "start";
    public const string EndName = "end";

    private readonly HashSet<Cave> linkedCaves = new();

    public string Name { get; }
    public bool IsStart => Name == StartName;
    public bool IsEnd => Name == EndName;
    public bool IsBig => Name == Name.ToUpper();
    public bool IsSmall => !IsBig;

    public Cave(string name) => Name = name;

    public void AddLink(Cave other)
    {
        if (linkedCaves.Contains(other))
            return;
        if (IsBig && other.IsBig)
            throw new InvalidOperationException($"Attempt to link two big caves ({this}, {other}) infinite loop coming");

        linkedCaves.Add(other);
        other.AddLink(this);
    }

    public IEnumerable<Route> GetRoutesToEnd(Route routeSoFar)
    {
        if (IsEnd)
        {
            yield return routeSoFar;
            yield break;
        }

        foreach (var cave in linkedCaves)
        {
            if (!routeSoFar.IsStepValid(cave))
                continue;

            var extendedRoute = routeSoFar.Copy();
            extendedRoute.AddCave(cave);
            foreach (var route in cave.GetRoutesToEnd(extendedRoute))
                yield return route;
        }
    }

    public override string ToString() => Name;
}
