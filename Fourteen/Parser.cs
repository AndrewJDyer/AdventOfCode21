namespace Fourteen;

internal class Parser
{
    private readonly string path;

    public Parser(string path) => this.path = path;

    public Polymer Parse()
    {
        var allLines = File.ReadAllLines(path);
        var template = allLines[0];
        var rulesLines = allLines[2..];
        var rules = ParseRules(rulesLines);

        return new Polymer(template, rules);
    }

    private IEnumerable<InsertionRule> ParseRules(string[] rulesLines) => rulesLines.Select(ParseRule);

    private InsertionRule ParseRule(string ruleLine)
    {
        if (ruleLine.Length != 7)
            throw new InvalidOperationException($"Unexpected rule line {ruleLine}");

        return new(ruleLine[0], ruleLine[1], ruleLine[6]);
    }
}
