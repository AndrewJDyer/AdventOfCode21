namespace Seventeen;

internal record Area(Range XRange, Range YRange)
{
    public bool Contains(Probe probe) => XRange.Contains(probe.Position.X) && YRange.Contains(probe.Position.Y);
}
