namespace Sixteen;

internal class LiteralPacket : Packet
{
    public int Value { get; }

    public LiteralPacket(Header header, int value)
        : base(header)
        => Value = value;

    public override int SumVersions() => Header.Version;
}
