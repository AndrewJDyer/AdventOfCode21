namespace Fifteen;

internal class CaveMap
{
    private readonly int[,] model;

    public int Width => model.GetLength(0) * 5;
    public int Height => model.GetLength(1) * 5;
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
    {
        if (!WithinRange(coordinate))
            throw new ArgumentOutOfRangeException(nameof(coordinate));

        var unnormalisedRisk = GetBasicRisk(coordinate) + GetProjectionModifier(coordinate);

        return NormaliseRisk(unnormalisedRisk);
    }

    private int GetBasicRisk(Coordinate coordinate)
    {
        var x = coordinate.X % model.GetLength(0);
        var y = coordinate.Y % model.GetLength(1);
        return model[x, y];
    }

    private int GetProjectionModifier(Coordinate coordinate)
    {
        var modifier = 0;
        for (int x = coordinate.X; x >= model.GetLength(0); x -= model.GetLength(0))
            modifier++;

        for (int y = coordinate.Y; y >= model.GetLength(1); y -= model.GetLength(1))
            modifier++;

        return modifier;
    }

    private static int NormaliseRisk(int value) => value < 10 ? value : value - 9;

    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate)
        => FilterByInRange(coordinate.Up(), coordinate.Down(), coordinate.Left(), coordinate.Right());

    private IEnumerable<Coordinate> FilterByInRange(params Coordinate[] coordinates) => coordinates.Where(WithinRange);

    private bool WithinRange(Coordinate coordinate) => WithinWidth(coordinate.X) && WithinHeight(coordinate.Y);

    private bool WithinWidth(int x) => x < Width && x > -1;

    private bool WithinHeight(int y) => y < Height && y > -1;
}
