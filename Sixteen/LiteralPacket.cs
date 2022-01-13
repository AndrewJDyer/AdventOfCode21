namespace Sixteen;

internal class LiteralPacket : Packet
{
    public long Value { get; }

    public LiteralPacket(Header header, long value)
        : base(header)
        => Value = value;

    public override int SumVersions() => Header.Version;

    public override long Evaluate() => Value;
}
