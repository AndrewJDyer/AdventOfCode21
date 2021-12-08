namespace Four;

internal class Entry
{
    public int Value { get; }
    public bool Marked { get; set; }

    public Entry(int value) => Value = value;
}
