namespace Sixteen;

internal class LiteralPacketBuilder
{
    private readonly BitStream stream;
    private readonly Header header;

    public LiteralPacketBuilder(BitStream stream, Header header)
    {
        this.stream = stream;
        this.header = header;
    }

    public LiteralPacket Build() => new(header, GetLiteralValue());

    private long GetLiteralValue()
    {
        var literalGroups = EnumerateLiteralGroups();
        var literalBinary = literalGroups.SelectMany(x => x);

        return new IntConversion(literalBinary).Convert();
    }

    private IEnumerable<bool[]> EnumerateLiteralGroups()
    {
        bool[] group;
        do
        {
            group = stream.GetNext(5);
            yield return group[1..];
        } while (group[0]);
    }
}
