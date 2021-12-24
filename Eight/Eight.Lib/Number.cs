using static Eight.Lib.Segment;

namespace Eight.Lib;

internal class Number
{
    public Segment[] Segments { get; }
    public int Value { get; }

    public static Number Zero => new(0, Top, UpperLeft, UpperRight, LowerLeft, LowerRight, Bottom);
    public static Number One => new(1, UpperRight, LowerRight);
    public static Number Two => new(2, Top, UpperRight, Middle, LowerLeft, Bottom);
    public static Number Three => new(3, Top, UpperRight, Middle, LowerRight, Bottom);
    public static Number Four => new(4, UpperLeft, UpperRight, Middle, LowerRight);
    public static Number Five => new(5, Top, UpperLeft, Middle, LowerRight, Bottom);
    public static Number Six => new(6, Top, UpperLeft, Middle, LowerLeft, LowerRight, Bottom);
    public static Number Seven => new(7, Top, UpperRight, LowerRight);
    public static Number Eight => new(8, Top, UpperLeft, UpperRight, Middle, LowerLeft, LowerRight, Bottom);
    public static Number Nine => new(9, Top, UpperLeft, UpperRight, Middle, LowerRight, Bottom);

    private Number(int value, params Segment[] segments)
    {
        Value = value;
        Segments = segments;
    }

    public static IEnumerable<Number> All => new[] { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine };

    public static IEnumerable<Number> GetPossibleNumbersByWordLength(string word) => All.Where(x => x.Segments.Length == word.Length);

    public override string ToString() => Value.ToString();
}
