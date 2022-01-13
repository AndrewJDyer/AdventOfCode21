namespace Sixteen;

internal class OperatorPacketBuilder
{
    private readonly BitStream stream;
    private readonly Header header;

    public OperatorPacketBuilder(BitStream stream, Header header)
    {
        this.stream = stream;
        this.header = header;
    }

    public OperatorPacket Build()
    {
        var lengthTypeId = GetLengthTypeId();
        return new OperatorPacket(header, BuildSubPackets(lengthTypeId));
    }

    private int GetLengthTypeId() => stream.GetNext() ? 1 : 0;

    private IEnumerable<Packet> BuildSubPackets(int lengthTypeId) => lengthTypeId switch
    {
        0 => BuildSubPacketCountingBits(),
        1 => BuildSubPacketsCountingPackets(),
        _ => throw new InvalidOperationException($"Unecpexted length type ID {lengthTypeId}")
    };

    private IEnumerable<Packet> BuildSubPacketCountingBits()
    {
        var lengthBits = stream.GetNext(15);
        var length = new IntConversion(lengthBits).Convert();
        return BuildSubPacketCountingBits(length);
    }

    private IEnumerable<Packet> BuildSubPacketCountingBits(long bitCount)
    {
        var initialBitsRemaining = stream.CountRemaining();
        while (initialBitsRemaining - stream.CountRemaining() < bitCount)
            yield return new PacketBuilder(stream).Build();
    }

    private IEnumerable<Packet> BuildSubPacketsCountingPackets()
    {
        var lengthBits = stream.GetNext(11);
        var length = new IntConversion(lengthBits).Convert();
        return BuildSubPacketsCountingPackets(length);
    }

    private IEnumerable<Packet> BuildSubPacketsCountingPackets(long packetCount)
    {
        for (int i = 0; i < packetCount; i++)
            yield return new PacketBuilder(stream).Build();
    }
}
