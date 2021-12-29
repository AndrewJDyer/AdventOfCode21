namespace Twelve;

internal class CaveSystem
{
    private readonly Dictionary<string, Cave> caves = new();

    public void Add(string caveName) => caves[caveName] = new(caveName);

    public void LinkByName(string firstCaveName, string secondCaveName)
        => caves[firstCaveName].AddLink(caves[secondCaveName]);

    public int CountRoutesToEnd()
    {
        var start = GetStart();
        var route = new Route(start);
        var routes = start.GetRoutesToEnd(route);

        return routes.Count();
    }

    private Cave GetStart() => caves[Cave.StartName];
}
