namespace Six;

/// <summary>
/// Model for part 2 (performance-optimised)
/// </summary>
internal class OceanModel : IOceanModel
{
    private readonly ClassCollection classes = new();

    public long Count => classes.Count;

    public OceanModel(IEnumerable<int> initialState)
    {
        foreach (var state in initialState)
            AddFish(state, 1);
    }

    public void NewDay() => classes.NewDay();

    private void AddFish(int fishTimer, long count) => classes[fishTimer].Add(count);
}
