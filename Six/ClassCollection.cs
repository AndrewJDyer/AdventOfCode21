namespace Six;

internal class ClassCollection
{
    private readonly List<FishClass> classes = new();
    private long spawnedToday = 0;

    public long Count => classes.Sum(x => x.Count);

    public FishClass this[int timer]
    {
        get
        {
            if (classes.SingleOrDefault(x => x.Timer == timer) is FishClass fishClass)
                return fishClass;

            var newClass = new FishClass(0, timer);
            classes.Add(newClass);
            newClass.Spawning += Class_Spawning;
            return newClass;
        }
    }

    private void Class_Spawning(object? sender, SpawnEventArgs e) => spawnedToday = e.Count;

    public void NewDay()
    {
        spawnedToday = 0;
        foreach (var fishClass in classes.ToList())
            fishClass.NewDay();

        if (spawnedToday != 0)
            this[8].Add(spawnedToday);

        ConsolidateClasses();
    }

    private void ConsolidateClasses()
    {
        for (int i = 0; i < 9; i++)
        {
            var classesForThisTimerVal = classes.Where(x => x.Timer == i).ToList();
            if (classesForThisTimerVal.Count > 1)
            {
                var toKeep = classesForThisTimerVal[0];
                for (int j = 1; j < classesForThisTimerVal.Count; j++)
                {
                    var toRemove = classesForThisTimerVal[j];
                    toKeep.Add(toRemove.Count);
                    classes.Remove(toRemove);
                }
            }
        }
    }

    public override string ToString() => String.Join(", ", classes.OrderBy(c => c.Timer));
}
