namespace Nine;

internal record Location(int X, int Y, int Height)
{
    public bool SharesBasinWith(Location other)
        => IsAdjacentTo(other) && Height != 9 && other.Height != 9;

    private bool IsAdjacentTo(Location other)
        => (other.X == X && (other.Y == Y - 1 || other.Y == Y + 1))
            || ((other.X == X - 1 || other.X == X + 1) && other.Y == Y);
}
