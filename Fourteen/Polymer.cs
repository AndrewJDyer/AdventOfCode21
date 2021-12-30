namespace Fourteen;

internal class Polymer
{
    private readonly List<char> polymer;
    private readonly Dictionary<(char, char), char> insertionRules;
    private readonly Dictionary<char, int> elementCounts = new();

    public IReadOnlyDictionary<char, int> ElementCounts => elementCounts;

    public Polymer(string template, IEnumerable<InsertionRule> rules)
    {
        polymer = template.ToList();
        insertionRules = rules.ToDictionary(x => (x.FirstChar, x.SecondChar), x => x.InsertionChar);

        foreach (var c in polymer)
            AppendElementCount(c);
    }

    public void RunRules(int iterations = 1)
    {
        for (int i = 0; i < iterations; i++)
            RunRules();
    }

    private void RunRules()
    {
        for (int i = polymer.Count - 1; i > 0; i--)
        {
            var firstChar = polymer[i - 1];
            var secondChar = polymer[i];
            if (insertionRules.TryGetValue((firstChar, secondChar), out var insertionChar))
            {
                polymer.Insert(i, insertionChar);
                AppendElementCount(insertionChar);
            }
        }
    }

    private void AppendElementCount(char c)
    {
        if (!elementCounts.ContainsKey(c))
            elementCounts[c] = 0;

        elementCounts[c]++;
    }
}
