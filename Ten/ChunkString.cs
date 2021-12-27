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
        while (index < text.Length)
        {
            try
            {
                RegisterChar();
            }
            catch (InvalidCharException)
            {
                return ScoreChar();
            }
            index++;
        }

        return 0;
    }

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
