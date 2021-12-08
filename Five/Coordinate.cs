namespace Five;

internal record Coordinate(int X, int Y)
{
    public Coordinate StepTowards(Coordinate other)
    {
        if (this == other)
            return this;

        return X == other.X ? StepVerticallyTowards(other) : StepHorizontallyTowards(other);
    }

    private Coordinate StepVerticallyTowards(Coordinate other)
    {
        if (other.Y == Y)
            throw new ArgumentException("Cannot take vertical step");

        return other.Y < Y ? new(X, Y - 1) : new(X, Y + 1);
    }

    private Coordinate StepHorizontallyTowards(Coordinate other)
    {
        if (other.X == X)
            throw new ArgumentException("Cannot take horizontal step");

        return other.X < X ? new(X - 1, Y) : new(X + 1, Y);
    }

    public static Coordinate operator +(Coordinate a, Coordinate b) => new(a.X + b.X, a.Y + b.Y);
    public static Coordinate operator -(Coordinate a, Coordinate b) => new(a.X - b.X, a.Y - b.Y);
}
