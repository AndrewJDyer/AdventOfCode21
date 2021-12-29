namespace Thirteen;

internal class Translation
{
    private readonly Coordinate coordinate;
    private readonly Fold fold;

    public bool GetsFolded => fold.Direction switch
    {
        FoldDirection.Horizontal => fold.Value < coordinate.X,
        FoldDirection.Vertical => fold.Value < coordinate.Y,
        _ => throw new InvalidOperationException("Unexpected fold direction " + fold.Direction)
    };

    public Translation(Coordinate coordinate, Fold fold)
    {
        this.coordinate = coordinate;
        this.fold = fold;
    }

    public Coordinate GetFoldedLocation()
    {
        if (!GetsFolded)
            return coordinate;

        return fold.Direction switch
        {
            FoldDirection.Horizontal => coordinate with { X = 2 * fold.Value - coordinate.X },
            FoldDirection.Vertical => coordinate with { Y = 2 * fold.Value - coordinate.Y },
            _ => throw new InvalidOperationException("Unexpected fold direction " + fold.Direction)
        };
    }
}
