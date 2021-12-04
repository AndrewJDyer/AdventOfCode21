namespace Three;

internal class BinaryNumber
{
    private readonly IReadOnlyList<bool> values;

    public int Count => values.Count;
    public bool this[int index] => values[index];

    public BinaryNumber(params bool[] values) : this(values.AsEnumerable()) { }

    public BinaryNumber(IEnumerable<bool> values) => this.values = values.ToList();

    public static BinaryNumber operator !(BinaryNumber binaryNum) => new(binaryNum.values.Select(x => !x));

    public static implicit operator int(BinaryNumber binaryNum)
    {
        var total = 0;
        for (int i = binaryNum.Count; i > 0; i--)
        {
            if (binaryNum.values[i - 1])
                total += Pow(2, binaryNum.Count - i);
        }

        return total;
        
        static int Pow(int x, int pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
    }

    public override string ToString() => new(AsChars());

    private char[] AsChars() => values.Select(x => x ? '1' : '0').ToArray();
}
