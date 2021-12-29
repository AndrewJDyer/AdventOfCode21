namespace Thirteen;

internal class Sheet
{
    private readonly HashSet<Coordinate> dotLocations;

    public int Dots => dotLocations.Count;

    public Sheet(HashSet<Coordinate> dots) => dotLocations = dots;

    public void DoFold(Fold fold)
    {
        foreach (var coordinate in dotLocations.ToList())
            Fold(coordinate, fold);
    }

    private void Fold(Coordinate coordinate, Fold fold)
    {
        var translation = new Translation(coordinate, fold);
        if (translation.GetsFolded)
            Replace(coordinate, translation.GetFoldedLocation());
    }

    private void Replace(Coordinate coordinate, Coordinate translatedCoordinate)
    {
        dotLocations.Remove(coordinate);
        dotLocations.Add(translatedCoordinate);
    }
}
