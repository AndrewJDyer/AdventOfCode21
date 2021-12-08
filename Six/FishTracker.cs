namespace Six;

internal class FishTracker
{
    private readonly Illumination illumination;

    public FishTracker(IEnumerable<Lanternfish> initialFishes) => illumination = new(initialFishes);

    public void IncrementDays(int newDays)
    {
        for (int i = 0; i < newDays; i++)
            illumination.NewDay();
    }

    public int CountFishes() => illumination.Count;
}
