namespace Four;

internal class InputParser
{
    private readonly string filePath;

    public InputParser(string filePath) => this.filePath = filePath;

    public (DrawSequence Sequence, IEnumerable<Board> Boards) Parse()
    {
        var lines = File.ReadAllLines(filePath).ToArray();
        var sequence = ParseDrawSequence(lines[0]);
        var boards = SplitIntoBoards(lines[1..]).Select(ParseBoard);

        return (sequence, boards);
    }

    private static DrawSequence ParseDrawSequence(string line)
    {
        var numbers = line.Split(',');
        return new(numbers.Select(int.Parse));
    }

    private static Board ParseBoard(IReadOnlyList<string> lines)
    {
        if (lines.Count != 5)
            throw new ArgumentException($"Expected 5 board lines, got {lines.Count} lines");

        var model = new int[5, 5];
        for (int x = 0; x < 5; x++)
        {
            var row = ParseBoardRow(lines[x]).ToArray();
            for (int y = 0; y < 5; y++)
                model[x, y] = row[y];
        }

        return new Board(model);
    }

    private static IEnumerable<int> ParseBoardRow(string line)
    {
        var split = line.Split(' ');
        foreach (var x in split)
        {
            if (String.IsNullOrWhiteSpace(x))
                continue;
            yield return int.Parse(x);
        }
    }

    private static IEnumerable<IReadOnlyList<string>> SplitIntoBoards(IEnumerable<string> lines)
    {
        var currentBoardLines = new List<string>();
        foreach (var line in lines)
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                if (currentBoardLines.Count > 0)
                {
                    yield return currentBoardLines;
                    currentBoardLines = new();
                }
            }
            else
            {
                currentBoardLines.Add(line);
            }
        }

        if (currentBoardLines.Count > 0)
            yield return currentBoardLines;
    }
}
