namespace Nine;

internal class Map
{
    private readonly int[,] heights;

    public int Width => heights.GetLength(0);
    public int Height => heights.GetLength(1);

    public Location this[int x, int y] => new(x, y, heights[x, y]);

    public Map(int[,] heights) => this.heights = heights;

    public IEnumerable<int> GetLowPoints()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (IsLowPoint(x, y))
                    yield return heights[x, y];
            }
        }
    }

    private bool IsLowPoint(int x, int y) => GetSurroundingHeights(x, y).All(h => h is null || h > heights[x, y]);

    private IEnumerable<int?> GetSurroundingHeights(int x, int y)
    {
        yield return GetHeight(x - 1, y);
        yield return GetHeight(x, y - 1);
        yield return GetHeight(x + 1, y);
        yield return GetHeight(x, y + 1);
    }

    private int? GetHeight(int x, int y) => IsInMap(x, y) ? heights[x, y] : null;

    private bool IsInMap(int x, int y) => x >= 0 && y >= 0 && x < Width && y < Height;
}
