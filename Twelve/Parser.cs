namespace Twelve;

internal class Parser
{
    private readonly string path;

    public Parser(string path) => this.path = path;

    public CaveSystem Parse()
    {
        var system = new CaveSystem();
        foreach (var name in ParseCaveNames())
            system.Add(name);

        foreach (var (firstCaveName, secondCaveName) in ParseCaveLinks())
            system.LinkByName(firstCaveName, secondCaveName);

        return system;
    }

    private IEnumerable<(string FirstCaveName, string SecondCaveName)> ParseCaveLinks()
    {
        foreach (var line in GetLines())
        {
            var split = line.Split('-');
            yield return (split[0], split[1]);
        }
    }

    private IEnumerable<string> ParseCaveNames()
        => ParseCaveLinks().SelectMany(l => new[] { l.FirstCaveName, l.SecondCaveName });

    private IEnumerable<string> GetLines() => File.ReadAllLines(path).Where(l => !string.IsNullOrWhiteSpace(l));
}
