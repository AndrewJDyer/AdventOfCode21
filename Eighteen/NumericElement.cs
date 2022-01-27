namespace Eighteen;

internal class NumericElement : Element
{
    private readonly bool left;
    private int value;

    public NumericElement(int value, bool left)
    {
        this.value = value;
        this.left = left;
    }

    public override int GetMagnitude() => value;

    public override bool TrySplit(out Element splitElement)
    {
        splitElement = this;
        if (value <= 9)
            return false;

        var leftVal = new NumericElement(value / 2, true);
        var rightVal = new NumericElement(value - leftVal.value, false);
        splitElement = new SnailfishPairElement(leftVal, rightVal);
        return true;
    }

    public override bool TryExplode() => false;

    public override void Reduce() { }

    public void Add(NumericElement number) => value += number.value;

    public override string ToString() => value.ToString();
}
