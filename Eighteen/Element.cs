namespace Eighteen;

internal abstract class Element
{
    public SnailfishPairElement? Parent { get; set; }

    public SnailfishPairElement? Source => Parent is null ? this as SnailfishPairElement : Parent.Source;

    public abstract bool TryExplode();

    public abstract bool TrySplit(out Element splitElement);

    public abstract int GetMagnitude();

    public abstract void Reduce();
}
