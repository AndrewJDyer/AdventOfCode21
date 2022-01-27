namespace Eighteen;

internal class SnailfishPairElement : Element
{
    private Element leftElement;
    private Element rightElement;

    private int Depth => Parent?.Depth + 1 ?? 0;

    private bool IsLeft => Parent?.leftElement == this;

    public SnailfishPairElement(Element leftElement, Element rightElement)
    {
        this.leftElement = leftElement;
        this.rightElement = rightElement;

        leftElement.Parent = this;
        rightElement.Parent = this;
    }

    public override void Reduce()
    {
        if (DoExplosions() || DoSplits())
            Reduce();
    }

    private bool DoExplosions()
    {
        if (!TryExplode())
            return false;

        DoExplosions();
        return true;
    }

    private bool DoSplits()
    {
        if (TrySplit(out _))
            return true;

        return false;
    }

    public override bool TrySplit(out Element splitElement)
    {
        splitElement = this;
        if (leftElement.TrySplit(out var leftSplit))
        {
            leftElement = leftSplit;
            leftElement.Parent = this;
            return true;
        }
        
        if (rightElement.TrySplit(out var rightSplit))
        {
            rightElement = rightSplit;
            rightElement.Parent = this;
            return true;
        }
        
        return false;
    }

    public override bool TryExplode()
    {
        if (Depth < 4 || leftElement is SnailfishPairElement || rightElement is SnailfishPairElement)
            return leftElement.TryExplode() || rightElement.TryExplode();

        var leftVal = (NumericElement)leftElement;
        var rightVal = (NumericElement)rightElement;
        FindNextNumberToTheLeft()?.Add(leftVal);
        FindNextNumberToTheRight()?.Add(rightVal);

        if (IsLeft)
            Parent!.leftElement = new NumericElement(0, true);
        else
            Parent!.rightElement = new NumericElement(0, false);

        return true;
    }

    public override int GetMagnitude() => 3 * leftElement.GetMagnitude() + 2 * rightElement.GetMagnitude();

    private NumericElement? FindNextNumberToTheLeft()
    {
        if (Parent is null)
            return null;

        if (IsLeft)
            return Parent.FindNextNumberToTheLeft();

        return Parent.leftElement switch
        {
            NumericElement number => number,
            SnailfishPairElement pair => pair.FindRightmostInSubtree(),
            _ => throw new InvalidOperationException("Unexpected element type")
        };
    }

    private NumericElement? FindNextNumberToTheRight()
    {
        if (Parent is null)
            return null;

        if (!IsLeft)
            return Parent.FindNextNumberToTheRight();

        return Parent.rightElement switch
        {
            NumericElement number => number,
            SnailfishPairElement pair => pair.FindLeftmostInSubtree(),
            _ => throw new InvalidOperationException("Unexpected element type")
        };
    }

    private NumericElement FindLeftmostInSubtree() => leftElement switch
    {
        NumericElement number => number,
        SnailfishPairElement pair => pair.FindLeftmostInSubtree(),
        _ => throw new InvalidOperationException("Unexpected element type")
    };

    private NumericElement FindRightmostInSubtree() => rightElement switch
    {
        NumericElement number => number,
        SnailfishPairElement pair => pair.FindRightmostInSubtree(),
        _ => throw new InvalidOperationException("Unexpected element type")
    };

    public static SnailfishPairElement operator +(SnailfishPairElement left, SnailfishPairElement right)
    {
        var sum = new SnailfishPairElement(left, right);
        sum.Reduce();
        return sum;
    }

    public override string ToString() => $"[{leftElement},{rightElement}]";
}
