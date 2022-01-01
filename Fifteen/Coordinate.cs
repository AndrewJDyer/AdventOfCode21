namespace Fifteen;

internal record Coordinate(int X, int Y)
{
    public static Coordinate Start => new(0, 0);

    public Coordinate Up() => new(X, Y - 1);
    public Coordinate Down() => new(X, Y + 1);
    public Coordinate Left() => new(X - 1, Y);
    public Coordinate Right() => new(X + 1, Y);
}
