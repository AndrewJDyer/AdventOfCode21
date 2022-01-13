namespace Sixteen;

internal class PacketBuilder
{
    private readonly BitStream stream;

    public PacketBuilder(BitStream stream) => this.stream = stream;

    public Packet Build()
    {
        var header = BuildHeader();
        return new LoggingPacket(header.IsLiteral ? BuildLiteral(header) : BuildOperator(header));
    }

    private Header BuildHeader()
    {
        var headerBits = stream.GetNext(6);
        return new(headerBits);
    }

    private LiteralPacket BuildLiteral(Header header)
        => new LiteralPacketBuilder(stream, header).Build();

    private OperatorPacket BuildOperator(Header header)
        => new OperatorPacketBuilder(stream, header).Build();
}
