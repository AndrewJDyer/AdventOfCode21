namespace Four;

internal class Board
{
    private readonly Entry[,] entries;

    public bool HaveWon { get; private set; }
    public int Score { get; private set; }

    public Board(int[,] numbers)
    {
        if (numbers.Rank != 2 || numbers.GetLength(0) != 5 || numbers.GetLength(1) != 5)
            throw new ArgumentException(nameof(numbers));

        entries = GetInitialEntries(numbers);
    }

    public void RegisterDraw(int drawnNumber)
    {
        if (HaveWon)
            return;

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                var entry = entries[x, y];
                if (entry.Value == drawnNumber)
                    entry.Marked = true;
            }
        }

        CheckIfWon(drawnNumber);
    }

    private void CheckIfWon(int drawnNumber)
    {
        if (HaveWinningRow() || HaveWinningColumn())
            SetHaveWon(drawnNumber);
    }

    private void SetHaveWon(int drawnNumber)
    {
        if (HaveWon)
            return;

        HaveWon = true;
        Score = CalculateScore(drawnNumber);
    }

    private bool HaveWinningRow()
    {
        for (int x = 0; x < 5; x++)
        {
            if (IsRowComplete(x))
                return true;
        }

        return false;
    }

    private bool IsRowComplete(int x)
    {
        for (int y = 0; y < 5; y++)
        {
            if (!entries[x, y].Marked)
                return false;
        }

        return true;
    }

    private bool HaveWinningColumn()
    {
        for (int y = 0; y < 5; y++)
        {
            if (IsColumnComplete(y))
                return true;
        }

        return false;
    }

    private bool IsColumnComplete(int y)
    {
        for (int x = 0; x < 5; x++)
        {
            if (!entries[x, y].Marked)
                return false;
        }

        return true;
    }

    private int CalculateScore(int lastDrawnNumber)
    {
        var score = 0;
        foreach (var entry in entries)
            score += entry.Marked ? 0 : entry.Value;

        return score * lastDrawnNumber;
    }

    private static Entry[,] GetInitialEntries(int[,] numbers)
    {
        var entries = new Entry[numbers.GetLength(0), numbers.GetLength(1)];
        for (int x = 0; x < numbers.GetLength(0); x++)
        {
            for (int y = 0; y < numbers.GetLength(1); y++)
                entries[x, y] = new(numbers[x, y]);
        }

        return entries;
    }
}
