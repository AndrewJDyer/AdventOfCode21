namespace Five;

internal record Coordinate(int X, int Y)
{
    public Coordinate StepTowards(Coordinate other)
    {
        if (this == other)
            return this;

        return this + GetVerticalStepTowards(other) + GetHorizontalStepTowards(other);
    }

    private Coordinate GetVerticalStepTowards(Coordinate other)
    {
        if (other.Y == Y)
            return new(0, 0);

        return other.Y < Y ? new(0, -1) : new(0, 1);
    }

    private Coordinate GetHorizontalStepTowards(Coordinate other)
    {
        if (other.X == X)
            return new(0, 0);

        return other.X < X ? new(-1, 0) : new(1, 0);
    }

    public static Coordinate operator +(Coordinate a, Coordinate b) => new(a.X + b.X, a.Y + b.Y);
    public static Coordinate operator -(Coordinate a, Coordinate b) => new(a.X - b.X, a.Y - b.Y);
}
