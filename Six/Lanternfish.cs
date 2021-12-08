namespace Six;

internal class Lanternfish
{
    private int timer;

    public event EventHandler<Lanternfish>? Spawned;

    public Lanternfish(int initialTimer) => timer = initialTimer;

    public void NewDay()
    {
        switch (timer)
        {
            case 0: SpawnAndReset(); break;
            case > 0: timer--; break;
            default: throw new InvalidOperationException($"Invalid timer value {timer}");
        };
    }

    private void SpawnAndReset()
    {
        timer = 6;
        Spawned?.Invoke(this, new(8));
    }
}
