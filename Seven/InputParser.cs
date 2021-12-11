namespace Seven;

static class InputParser
{
    public static IEnumerable<int> Parse(string path)
    {
        var text = File.ReadAllText(path);
        var intStrings = text.Split(',');
        return intStrings.Select(int.Parse);
    }
}