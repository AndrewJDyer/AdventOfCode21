namespace Six;

internal class FishClass
{
    public int Timer { get; private set; }
    public long Count { get; private set; }

    public event EventHandler<SpawnEventArgs> Spawning;

    public FishClass(long count, int timer)
    {
        Count = count;
        Timer = timer;
    }

    public void Add(long newFishes) => Count += newFishes;

    public void NewDay()
    {
        if (Timer == 0)
            SpawnAndReset();
        else
            Timer--;
    }

    private void SpawnAndReset()
    {
        Spawning?.Invoke(null, new(Count));
        Timer = 6;
    }

    public override string ToString() => $"Timer: {Timer}; Count: {Count}";
}
