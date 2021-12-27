namespace Eleven;

internal class SyncNotifier
{
    private readonly Cavern cavern;

    public SyncNotifier(Cavern cavern)
    {
        this.cavern = cavern;
        foreach (var octopus in cavern.Octopi)
            octopus.Initialise();
    }

    public int GetRoundOfFirstSync()
    {
        for (int roundCount = 1; true; roundCount++)
        {
            var roundRunner = new RoundRunner(cavern);
            roundRunner.RunRound();
            if (roundRunner.OctopiAreSynchronised)
                return roundCount;
        }
    }

    private class RoundRunner
    {
        private readonly Cavern cavern;
        private int flashCount;

        public bool OctopiAreSynchronised => flashCount == cavern.Octopi.Count();

        public RoundRunner(Cavern cavern)
        {
            this.cavern = cavern;
            foreach (var octopus in cavern.Octopi)
                octopus.Flash += (_, _) => flashCount++;
        }

        public void RunRound()
        {
            foreach (var octopus in cavern.Octopi)
                octopus.ResetRound();

            foreach (var octopus in cavern.Octopi)
                octopus.Step();
        }
    }
}
