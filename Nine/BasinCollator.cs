namespace Nine;

internal class BasinCollator
{
    private readonly List<Basin> basins = new();
    private readonly Map map;

    public BasinCollator(Map map) => this.map = map;

    public int MultiplyThreeLargestBasinSizes()
    {
        var largestBasins = GetThreeLargestBasins().ToList();
        return largestBasins[0].Size * largestBasins[1].Size * largestBasins[2].Size;
    }

    private IEnumerable<Basin> GetThreeLargestBasins()
        => GetBasins().OrderByDescending(b => b.Size).Take(3);
    private IEnumerable<Basin> GetBasins()
    {
        for (int x = 0;  x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
                AddLocation(map[x, y]);
        }

        MergeBasins();
        return basins;
    }

    private void AddLocation(Location location)
    {
        if (location.Height == 9)
            return;

        foreach (var basin in basins)
        {
            if (basin.Contains(location))
            {
                basin.Add(location);
                return;
            }
        }

        var newBasin = new Basin();
        newBasin.Add(location);
        basins.Add(newBasin);
    }

    private void MergeBasins()
    {
        var anyMerges = false;
        for (int i = basins.Count - 1; i >= 0; i--)
        {
            for (int j = basins.Count - 1; j > i; j--)
            {
                if (!basins[j].IsSameBasinAs(basins[i]))
                    continue;

                basins[i].Merge(basins[j]);
                basins.RemoveAt(j);
                anyMerges = true;
            }
        }

        if (anyMerges)
            MergeBasins();
    }
}
