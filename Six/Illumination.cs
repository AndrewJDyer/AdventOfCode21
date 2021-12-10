namespace Six;

/// <summary>
/// Model for part 1 (not performance-optimised)
/// </summary>
internal class Illumination : IOceanModel
{
    private readonly List<Lanternfish> fishes = new();

    public long Count => fishes.Count;

    public Illumination(IEnumerable<Lanternfish> initialPopulation)
    {
        foreach (var fish in initialPopulation)
            AddFish(fish);
    }

    private void AddFish(Lanternfish fish)
    {
        fishes.Add(fish);
        SubscribeForSpawnings(fish);
    }

    public void NewDay()
    {
        for (int i = fishes.Count - 1; i >= 0; i--)
            fishes[i].NewDay();
    }

    private void SubscribeForSpawnings(Lanternfish fish) => fish.Spawned += Fish_Spawned;

    private void Fish_Spawned(object? _, Lanternfish spawnedFish) => AddFish(spawnedFish);
}
