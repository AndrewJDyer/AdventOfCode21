namespace Seventeen;

internal record Velocity(int X, int Y)
{
    public Velocity Step() => new(GetNextX(), GetNextY());

    private int GetNextX() => X switch
    {
        < 0 => X + 1,
        > 0 => X - 1,
        0 => 0
    };

    private int GetNextY() => Y - 1;
}
