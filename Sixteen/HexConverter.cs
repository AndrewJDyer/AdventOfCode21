namespace Sixteen;

internal class HexConverter
{
    private readonly string hexStream;

    public HexConverter(string hexStream) => this.hexStream = hexStream;

    public BitStream ToBinary()
    {
        var binaryWords = hexStream.Select(ToBinary);
        var bits = Join(binaryWords);

        return new BitStream(bits);
    }

    private static BinaryWord ToBinary(char hexChar)
    {
        var intVal = Convert.ToInt32($"0x{hexChar}", 16);
        return new(Convert.ToString(intVal, toBase: 2));
    }

    private static IEnumerable<bool> Join(IEnumerable<BinaryWord> binaryWords) => binaryWords.SelectMany(b => b.GetBits());

    private class BinaryWord
    {
        private readonly string binaryString;

        public BinaryWord(string binaryString) => this.binaryString = FormatBinaryWord(binaryString);

        private static string FormatBinaryWord(string binaryString) => binaryString.Length switch
        {
            4 => binaryString,
            < 4 => FormatBinaryWord($"0{binaryString}"),
            > 4 => throw new ArgumentOutOfRangeException(nameof(binaryString))
        };

        public IEnumerable<bool> GetBits() => binaryString.Select(GetBit);

        private static bool GetBit(char c) => c switch
        {
            '0' => false,
            '1' => true,
            _ => throw new InvalidOperationException($"Cannot convert character '{c}' to a boolean value")
        };
    }
}
