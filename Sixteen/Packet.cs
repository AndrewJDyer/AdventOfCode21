namespace Sixteen;

internal abstract class Packet
{
    public Header Header { get; }

    public Packet(Header header) => Header = header;

    public abstract int SumVersions();

    public abstract long Evaluate();
}
