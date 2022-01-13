using Sixteen;
using Sixteen.Properties;

var bits = new HexConverter(Resources.BITS).ToBinary();
var builder = new PacketBuilder(bits);
var superPacket = builder.Build();

var packetEvaluation = superPacket.Evaluate();

Console.WriteLine(packetEvaluation);
