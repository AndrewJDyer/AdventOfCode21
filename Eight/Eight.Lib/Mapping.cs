namespace Eight.Lib;

internal class Mapping
{
    private readonly Dictionary<char, Segment> finalMapping = new();

    public IReadOnlyDictionary<char, Segment> FinalMapping
        => HaveFinalMapping ? finalMapping : throw new InvalidOperationException("No final mapping available");

    public bool HaveFinalMapping => HaveMappingFor('a', 'b', 'c', 'd', 'e', 'f', 'g');

    private bool HaveMappingFor(params char[] chars) => chars.All(finalMapping.ContainsKey);
}
