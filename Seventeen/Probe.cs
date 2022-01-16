namespace Seventeen;

internal class Probe
{
    private Velocity velocity;

    public Position Position { get; private set; } = new();

    public Probe(Velocity initialVelocity) => velocity = initialVelocity;

    public void Step()
    {
        Position.Increment(velocity);
        velocity = velocity.Step();
    }

    public bool HasOvershot(Area target) => HasOvershotX(target.XRange) || HasOvershotY(target.YRange);

    private bool HasOvershotX(Range targetX) => Position.X > targetX.Upper && velocity.X >= 0;

    private bool HasOvershotY(Range targetY) => Position.Y < targetY.Lower && velocity.Y <= 0;
}
