using System.Text;

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

    public override string ToString()
    {
        var width = dotLocations.Max(dot => dot.X);
        var height = dotLocations.Max(dot => dot.Y);

        var buf = new StringBuilder();
        for (int y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++)
                buf.Append(HasDotAt(x, y) ? '#' : ' ');
            buf.AppendLine();
        }

        return buf.ToString();
    }

    private bool HasDotAt(int x, int y) => dotLocations.Contains(new(x, y));
}
