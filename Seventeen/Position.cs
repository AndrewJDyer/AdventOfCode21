namespace Seventeen;

internal class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public void Increment(Velocity velocity)
    {
        X += velocity.X;
        Y += velocity.Y;
    }
}
