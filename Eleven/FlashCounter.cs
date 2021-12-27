namespace Eleven;

internal class FlashCounter
{
    private readonly Cavern cavern;
    private readonly int rounds;

    private int flashCount = 0;

    private IEnumerable<Octopus> Octopi => cavern.Octopi;

    public FlashCounter(Cavern cavern, int rounds)
    {
        this.cavern = cavern;
        this.rounds = rounds;

        foreach (var octopus in Octopi)
        {
            octopus.Initialise();
            octopus.Flash += Octopus_Flash;
        }
    }

    private void Octopus_Flash(object? sender, EventArgs e) => flashCount++;

    public int Count()
    {
        for (int i = 0; i < rounds; i++)
            RunRound();

        return flashCount;
    }

    private void RunRound()
    {
        foreach (var octopus in Octopi)
            octopus.ResetRound();

        foreach (var octopus in Octopi)
            octopus.Step();
    }
}
