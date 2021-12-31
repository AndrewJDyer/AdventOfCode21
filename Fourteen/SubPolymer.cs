namespace Fourteen;

internal class SubPolymer : IEquatable<SubPolymer>
{
    private readonly Pair pair;
    private readonly IReadOnlyDictionary<Pair, char> insertionRules;

    public char FirstElement => pair.FirstChar;

    public SubPolymer(Pair pair, IReadOnlyDictionary<Pair, char> insertionRules)
    {
        this.pair = pair;
        this.insertionRules = insertionRules;
    }

    public IEnumerable<SubPolymer> Iterate()
    {
        if (!insertionRules.TryGetValue(pair, out var insertionChar))
        {
            yield return this;
            yield break;
        }

        yield return new(new(pair.FirstChar, insertionChar), insertionRules);
        yield return new(new(insertionChar, pair.SecondChar), insertionRules);
    }

    public bool Equals(SubPolymer? other) => other is not null && pair.Equals(other.pair);

    public override bool Equals(object? obj) => Equals(obj as SubPolymer);

    public override int GetHashCode() => pair.GetHashCode();
}
