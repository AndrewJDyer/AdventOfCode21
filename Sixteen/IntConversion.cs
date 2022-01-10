namespace Sixteen;

internal class IntConversion
{
    private readonly Stack<bool> bits;

    private int digitMultiplier = 1;
    private int cumulativeValue;

    public IntConversion(IEnumerable<bool> bits) => this.bits = new(bits);

    public int Convert()
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

    private int GetDigitValue(bool bit) => bit ? digitMultiplier : 0;
}
