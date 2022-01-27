namespace Eighteen;

internal class NumericElement : Element
{
    private int value;

    public NumericElement(int value) => this.value = value;

    public NumericElement Clone() => new(value);

    public override int GetMagnitude() => value;

    public override bool TrySplit(out Element splitElement)
    {
        splitElement = this;
        if (value <= 9)
            return false;

        var leftVal = new NumericElement(value / 2);
        var rightVal = new NumericElement(value - leftVal.value);
        splitElement = new SnailfishPairElement(leftVal, rightVal);
        return true;
    }

    public override bool TryExplode() => false;

    public override void Reduce() { }

    public void Add(NumericElement number) => value += number.value;

    public override string ToString() => value.ToString();
}
