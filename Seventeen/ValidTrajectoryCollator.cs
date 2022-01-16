namespace Seventeen;

internal class ValidTrajectoryCollator
{
    private readonly Area targetArea;

    public ValidTrajectoryCollator(Area targetArea) => this.targetArea = targetArea;

    public int FindMaxHeight() => Collate().Max(x => x.MaxHeight);

    public int CountValidTrajectories() => Collate().Count();

    private IEnumerable<ValidTrajectory> Collate()
    {
        for (int y = FindMinInitialVerticalSpeed(); y <= FindMaxInitialVerticalSpeed(); y++)
        {
            for (int x = FindMinInitialHorizontalSpeed(); x <= FindMaxInitialHorizontalSpeed(); x++)
            {
                var initialVelocity = new Velocity(x, y);
                var probe = new Probe(initialVelocity);
                var tracker = new ProbeTracker(probe, targetArea);
                if (tracker.HitsTarget())
                {
                    Console.WriteLine($"Probe with initial velocity {initialVelocity} reaches max height of {tracker.MaxHeight}");
                    yield return new(initialVelocity, tracker.MaxHeight);
                }
            }
        }
    }

    private int FindMinInitialHorizontalSpeed()
    {
        var trialSpeed = 0;
        while (true)
        {
            if (WillReachTarget(++trialSpeed))
                return trialSpeed;
        }

        bool WillReachTarget(int initialXSpeed)
        {
            var xPosReached = 0;
            for (int xSpeed = initialXSpeed; xSpeed > 0; xSpeed--)
                xPosReached += xSpeed;

            return xPosReached >= targetArea.XRange.Lower;
        }
    }

    private int FindMinInitialVerticalSpeed() => targetArea.YRange.Lower;

    private int FindMaxInitialHorizontalSpeed() => targetArea.XRange.Upper;

    private int FindMaxInitialVerticalSpeed()
    {
        //We know that at on the way down, the probe will reach Y=0 with:
        //Velocity.Y = -InitialVelocity.Y
        //...so InitialVelocity.Y should be < -targetArea.YRange.Lower
        return -targetArea.YRange.Lower;
    }
}
