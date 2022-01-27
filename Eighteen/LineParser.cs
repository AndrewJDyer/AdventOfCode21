namespace Eighteen;

internal class LineParser
{
    private readonly CharEnumerator enumerator;

    private char CurrentChar => enumerator.Current;

    public LineParser(string text) => enumerator = text.GetEnumerator();

    public SnailfishPairElement Parse()
    {
        if (!enumerator.MoveNext() || CurrentChar != '[')
            throw new InvalidOperationException("Invalid row");

        var (left, right) = ParsePair();
        return new SnailfishPairElement(left, right);
    }

    private Element ParseElement()
    {
        if (!enumerator.MoveNext())
            throw new InvalidOperationException("No text left");

        if (CurrentChar == '[')
        {
            var (leftElem, rightElem) = ParsePair();
            var pair = new SnailfishPairElement(leftElem, rightElem);
            if (!enumerator.MoveNext() || CurrentChar != ']')
                throw new InvalidOperationException("No closing bracket found");
            return pair;
        }

        if (Int32.TryParse(CurrentChar.ToString(), out var val))
            return new NumericElement(val);

        throw new InvalidOperationException("Unexpected character");
    }

    private (Element Left, Element Right) ParsePair()
    {
        var left = ParseElement();
        if (!enumerator.MoveNext() || CurrentChar != ',')
            throw new InvalidOperationException("Expected 2nd element in pair");

        var right = ParseElement();

        return (left, right);
    }
}
