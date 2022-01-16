namespace Seventeen;

internal class ProbeTracker
{
    private readonly Probe probe;
    private readonly Area targetArea;

    public int MaxHeight { get; private set; }

    public ProbeTracker(Probe probe, Area targetArea)
    {
        this.probe = probe;
        this.targetArea = targetArea;

        MaxHeight = probe.Position.Y;
    }

    public bool HitsTarget()
    {
        while (true)
        {
            Step();
            if (targetArea.Contains(probe))
                return true;
            else if (probe.HasOvershot(targetArea))
                return false;
        }
    }

    private void Step()
    {
        probe.Step();
        ReEvaluateMaxHeight();
    }

    private void ReEvaluateMaxHeight()
    {
        if (probe.Position.Y > MaxHeight)
            MaxHeight = probe.Position.Y;
    }
}
