namespace Fifteen;

internal class CaveMap
{
    private readonly int[,] model;

    public int Width => model.GetLength(0);
    public int Height => model.GetLength(1);
    public Coordinate Start => Coordinate.Start;
    public Coordinate End => new(Width - 1, Height - 1);
    public IEnumerable<Coordinate> AllCoordinates
    {
        get
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                    yield return new(x, y);
            }
        }
    }

    public CaveMap(int[,] model) => this.model = model;

    public int Risk(Coordinate coordinate)
        => WithinRange(coordinate) ? model[coordinate.X, coordinate.Y] : throw new ArgumentOutOfRangeException(nameof(coordinate));

    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate)
        => FilterByInRange(coordinate.Up(), coordinate.Down(), coordinate.Left(), coordinate.Right());

    private IEnumerable<Coordinate> FilterByInRange(params Coordinate[] coordinates) => coordinates.Where(WithinRange);

    private bool WithinRange(Coordinate coordinate) => WithinWidth(coordinate.X) && WithinHeight(coordinate.Y);

    private bool WithinWidth(int x) => x < Width && x > -1;

    private bool WithinHeight(int y) => y < Height && y > -1;
}
