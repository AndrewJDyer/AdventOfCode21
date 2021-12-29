using System.Text.RegularExpressions;

namespace Thirteen;

internal class Parser
{
    private readonly string path;
    private readonly Lazy<ICollection<string>> lines;

    public Parser(string path)
    {
        this.path = path;
        lines = new(GetLines);
    }

    private ICollection<string> GetLines()
        => File.ReadAllLines(path).Where(l => !String.IsNullOrEmpty(l)).ToArray();

    public (Sheet Sheet, IReadOnlyList<Fold> Instructions) Parse()
        => (ParseSheet(), ParseFolds());

    private Sheet ParseSheet()
    {
        var coordinates = GetCoordinateLines().Select(ParseCoordinate);
        return new(new HashSet<Coordinate>(coordinates));
    }

    private static Coordinate ParseCoordinate(string line)
    {
        var split = line.Split(',');
        return new(int.Parse(split[0]), int.Parse(split[1]));
    }

    private IReadOnlyList<Fold> ParseFolds() => GetFoldInstructionLines().Select(ParseFold).ToList();

    private static Fold ParseFold(string line)
    {
        var match = Regex.Match(line, @"fold along ([xy])=(\d+)");
        var direction = match.Groups[1].Value;
        var value = match.Groups[2].Value;

        return new(ParseFoldDirection(direction), int.Parse(value));
    }

    private static FoldDirection ParseFoldDirection(string direction) => direction switch
    {
        "x" => FoldDirection.Horizontal,
        "y" => FoldDirection.Vertical,
        _ => throw new InvalidOperationException($"Invalid direction {direction}")
    };

    private IEnumerable<string> GetCoordinateLines()
        => lines.Value.Where(IsCoordinateLine);

    private IEnumerable<string> GetFoldInstructionLines()
        => lines.Value.Where(IsFoldInstruction);

    private static bool IsCoordinateLine(string line) => !IsFoldInstruction(line);
    private static bool IsFoldInstruction(string line) => line.StartsWith("fold along");
}
