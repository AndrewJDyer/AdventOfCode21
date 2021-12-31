namespace Fourteen;

internal class Polymer
{
    private readonly string template;
    private readonly IReadOnlyDictionary<Pair, char> insertionRules;
    private Dictionary<SubPolymer, long> pairs;

    public IReadOnlyDictionary<char, long> ElementCounts => CountElements();

    public Polymer(string template, IEnumerable<InsertionRule> rules)
    {
        this.template = template;
        insertionRules = rules.ToDictionary(x => x.Pair, x => x.InsertionChar);
        pairs = ToSubPolymers(template, insertionRules);
    }

    private static Dictionary<SubPolymer,long> ToSubPolymers(string template, IReadOnlyDictionary<Pair, char> rules)
    {
        var subPolymers = new Dictionary<SubPolymer, long>();
        for (int i = 1; i < template.Length; i++)
        {
            var pair = new Pair(template[i - 1], template[i]);
            var subPolymer = new SubPolymer(pair, rules);
            if (subPolymers.ContainsKey(subPolymer))
                subPolymers[subPolymer]++;
            else
                subPolymers[subPolymer] = 1;
        }
        return subPolymers;
    }

    public void RunRules(int iterations = 1)
    {
        for (int i = 0; i < iterations; i++)
        {
            Console.WriteLine($"Running iteration {i}");
            RunRules();
        }
    }

    private void RunRules() => pairs = FormNewPolymers();

    private Dictionary<SubPolymer, long> FormNewPolymers()
    {
        var newPairs = new Dictionary<SubPolymer, long>();
        foreach(var kvp in pairs)
        {
            var newPolymers = kvp.Key.Iterate();
            foreach (var polymer in newPolymers)
            {
                if (newPairs.ContainsKey(polymer))
                    newPairs[polymer] += kvp.Value;
                else
                    newPairs[polymer] = kvp.Value;
            }
        }

        return newPairs;
    }

    private IReadOnlyDictionary<char, long> CountElements()
    {
        var elements = insertionRules.Select(r => r.Value).Distinct();
        return elements.ToDictionary(e => e, CountElement);
    }

    private long CountElement(char element)
    {
        var total = template[^1] == element ? 1L : 0L;
        foreach (var kvp in pairs)
        {
            if (kvp.Key.FirstElement == element)
                total += kvp.Value;
        }

        return total;
    }
}
