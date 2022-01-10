using Sixteen;
using Sixteen.Properties;

var bits = new HexConverter(Resources.BITS).ToBinary();
var builder = new PacketBuilder(bits);
var superPacket = builder.Build();

var summedVersions = superPacket.SumVersions();

Console.WriteLine(summedVersions);

