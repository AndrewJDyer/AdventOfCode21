namespace Sixteen
{
    internal class OperatorPacket : Packet
    {
        public IEnumerable<Packet> SubPackets { get; }

        public OperatorPacket(Header header, IEnumerable<Packet> subPackets)
            : base(header)
            => SubPackets = subPackets;

        public override int SumVersions() => Header.Version + SubPackets.Sum(p => p.SumVersions());
    }
}
