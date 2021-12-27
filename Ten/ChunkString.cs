namespace Ten;

internal class ChunkString
{
    private readonly string text;
    private readonly Stack<char> openingBrackets = new();
    private static readonly Dictionary<char, char> bracketPairs = new()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' }
    };

    private int index;

    public ChunkString(string text) => this.text = text;

    public int CalculateErrorScore()
    {
        for (index = 0; index < text.Length; index++)
        {
            try
            {
                RegisterChar();
            }
            catch (InvalidCharException)
            {
                return ScoreChar();
            }
        }

        return 0;
    }

    public long CalculateIncompleteScore()
    {
        if (CalculateErrorScore() != 0)
            return 0;

        return ScoreIncompleteChars();
    }

    private long ScoreIncompleteChars()
    {
        var score = 0L;
        while (openingBrackets.Count > 0)
            score = (score * 5) + ScoreIncompleteChar();

        return score;
    }

    private int ScoreIncompleteChar() => bracketPairs[openingBrackets.Pop()] switch
    {
        ')' => 1,
        ']' => 2,
        '}' => 3,
        '>' => 4,
        _ => throw new InvalidCharException()
    };

    private bool IsOpeningBracket() => bracketPairs.ContainsKey(GetCurrentChar());

    private char GetExpectedClosingBrace()
    {
        if (openingBrackets.Count == 0)
            throw new InvalidCharException();

        return bracketPairs[openingBrackets.Peek()];
    }

    private int ScoreChar() => GetCurrentChar() switch
    {
        ')' => 3,
        ']' => 57,
        '}' => 1197,
        '>' => 25137,
        _ => throw new InvalidCharException()
    };

    private void RegisterChar()
    {
        if (IsOpeningBracket())
            openingBrackets.Push(GetCurrentChar());
        else if (GetCurrentChar() == GetExpectedClosingBrace())
            openingBrackets.Pop();
        else
            throw new InvalidCharException();
    }

    private char GetCurrentChar() => text[index];

    private class InvalidCharException : Exception { }
}
