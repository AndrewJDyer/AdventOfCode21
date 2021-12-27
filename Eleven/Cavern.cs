namespace Eleven;

internal class Cavern
{
    private readonly Octopus[,] octopusMap;
    private readonly int width;
    private readonly int height;

    public IEnumerable<Octopus> Octopi
    {
        get
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    yield return octopusMap[x, y];
            }
        }
    }

    public Cavern(int[,] initialEnergyLevels)
    {
        width = initialEnergyLevels.GetLength(0);
        height = initialEnergyLevels.GetLength(1);
        octopusMap = GetOctopusMap();

        Octopus[,] GetOctopusMap()
        {
            var map = new Octopus[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var capturedX = x;
                    var capturedY = y;
                    map[x, y] = new Octopus(initialEnergyLevels[x, y], new(() => GetNeighbours(capturedX, capturedY).ToList()));
                }
            }
            return map;
        }
    }

    private IEnumerable<Octopus> GetNeighbours(int x, int y)
    {
        if (IsInRange(x - 1, y))
            yield return octopusMap[x - 1, y];
        if (IsInRange(x - 1, y - 1))
            yield return octopusMap[x - 1, y - 1];
        if (IsInRange(x - 1, y + 1))
            yield return octopusMap[x - 1, y + 1];
        if (IsInRange(x + 1, y))
            yield return octopusMap[x + 1, y];
        if (IsInRange(x + 1, y - 1))
            yield return octopusMap[x + 1, y - 1];
        if (IsInRange(x + 1, y + 1))
            yield return octopusMap[x + 1, y + 1];
        if (IsInRange(x, y - 1))
            yield return octopusMap[x, y - 1];
        if (IsInRange(x, y + 1))
            yield return octopusMap[x, y + 1];
    }

    private bool IsInRange(int x, int y) => x >= 0 && y >= 0 && x < width && y < height;

    public override string ToString() => String.Join('|', GetRowStrings());

    private IEnumerable<string> GetRowStrings() => Enumerable.Range(0, height).Select(GetRowString);

    private string GetRowString(int y) => String.Join(' ', GetRow(y));

    private IEnumerable<Octopus> GetRow(int y) => Enumerable.Range(0, width).Select(x => octopusMap[x, y]);
}
