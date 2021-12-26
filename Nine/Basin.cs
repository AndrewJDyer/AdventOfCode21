namespace Nine;

internal class Basin
{
    private readonly List<Location> locations = new();

    public int Size => locations.Count;

    public bool Contains(Location location) => locations.Any(location.SharesBasinWith);

    public void Add(Location location) => locations.Add(location);

    public void Merge(Basin other) => locations.AddRange(other.locations);

    public bool IsSameBasinAs(Basin other) => locations.Any(other.Contains);
}
