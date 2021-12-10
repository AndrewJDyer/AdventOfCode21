namespace Six;

internal class FishTracker
{
    private readonly IOceanModel model;

    public FishTracker(IOceanModel model) => this.model = model;

    public void IncrementDays(int newDays)
    {
        for (int i = 0; i < newDays; i++)
            model.NewDay();
    }

    public long CountFishes() => model.Count;
}
