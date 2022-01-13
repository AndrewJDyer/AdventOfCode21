namespace Sixteen
{
    internal class OperatorPacket : Packet
    {
        public IEnumerable<Packet> SubPackets { get; }

        public OperatorPacket(Header header, IEnumerable<Packet> subPackets)
            : base(header)
            => SubPackets = subPackets;

        public override int SumVersions() => Header.Version + SubPackets.Sum(p => p.SumVersions());

        public override long Evaluate() => Header.TypeId switch
        {
            TypeId.Sum => Sum(),
            TypeId.Product => Multiply(),
            TypeId.Minimum => GetMin(),
            TypeId.Maximum => GetMax(),
            TypeId.GreaterThan => EvaluateGreaterThan(),
            TypeId.LessThan => EvaluateLessThan(),
            TypeId.EqualTo => EvaluateEqualTo(),
            _ => throw new InvalidOperationException($"Unexpected TypeId {Header.TypeId}")
        };

        private long Sum() => SubPackets.Sum(x => x.Evaluate());

        private long Multiply()
        {
            var value = 1L;
            foreach (var subPacket in SubPackets)
                value *= subPacket.Evaluate();

            return value;
        }

        private long GetMin() => SubPackets.Select(p => p.Evaluate()).Min();

        private long GetMax() => SubPackets.Select(p => p.Evaluate()).Max();

        private long EvaluateGreaterThan() => EvaluatePairOperator((x, y) => x > y);

        private long EvaluateLessThan() => EvaluatePairOperator((x, y) => x < y);

        private long EvaluateEqualTo() => EvaluatePairOperator((x, y) => x == y);

        private long EvaluatePairOperator(Func<long, long, bool> isMatch)
        {
            var (first, second) = SplitSubPacketIntoPair();
            return isMatch(first.Evaluate(), second.Evaluate()) ? 1 : 0;
        }

        private (Packet First, Packet Second) SplitSubPacketIntoPair()
        {
            var subPackets = SubPackets.ToList();
            if (subPackets.Count != 2)
                throw new InvalidOperationException($"Unexpected number of subpackets for Greater Than operator packet: {subPackets.Count}");

            return (subPackets[0], subPackets[1]);
        }
    }
}
