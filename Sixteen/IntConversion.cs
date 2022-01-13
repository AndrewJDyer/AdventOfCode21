namespace Sixteen;

internal class IntConversion
{
    private readonly Stack<bool> bits;

    private long digitMultiplier = 1;
    private long cumulativeValue;

    public IntConversion(IEnumerable<bool> bits) => this.bits = new(bits);

    public long Convert()
    {
        while (bits.Count > 0)
            ConvertBit(bits.Pop());

        return cumulativeValue;
    }

    private void ConvertBit(bool bit)
    {
        cumulativeValue += GetDigitValue(bit);
        digitMultiplier *= 2;
    }

    private long GetDigitValue(bool bit) => bit ? digitMultiplier : 0;
}
