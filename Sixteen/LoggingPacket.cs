namespace Sixteen;

internal class LoggingPacket : Packet
{
    private static int Id = 1;

    private readonly int id = Id++;
    private readonly Packet packet;

    public LoggingPacket(Packet packet)
        : base(packet.Header)
        => this.packet = packet;

    public override long Evaluate()
    {
        var value = packet.Evaluate();
        Console.WriteLine($"Evaluating {GetPacketDescription()} packet {id}, Value = {value}");
        return value;
    }

    public override int SumVersions() => packet.SumVersions();

    private string GetPacketDescription() => packet switch
    {
        LiteralPacket _ => "literal",
        OperatorPacket op => $"{op.Header.TypeId} operator",
        _ => throw new InvalidOperationException("Unexpected packet type")
    };
}
