namespace Sixteen;

internal class BitStream
{
    private readonly Queue<bool> bits;

    public BitStream(IEnumerable<bool> bits) => this.bits = new(bits);

    public bool GetNext() => bits.Dequeue();

    public bool[] GetNext(int count) => EnumerateNext(count).ToArray();

    public int CountRemaining() => bits.Count;

    private IEnumerable<bool> EnumerateNext(int count)
    {
        for (int i = 0; i < count; i++)
            yield return GetNext();
    }

    public override string ToString() => new(GetChars().ToArray());

    private IEnumerable<char> GetChars() => bits.Select(bit => bit ? '1' : '0');
}
