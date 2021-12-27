namespace Eleven;

internal class Octopus
{
    private readonly Lazy<ICollection<Octopus>> neighbours;
    private readonly EnergyLevel energy;

    private bool flashedThisStep = false;

    private IEnumerable<Octopus> Neighbours => neighbours.Value;

    public event EventHandler? Flash;

    public Octopus(int energy, Lazy<ICollection<Octopus>> neighbours)
    {
        this.neighbours = neighbours;
        this.energy = new(energy);

        this.energy.Flash += Energy_Flash;
    }

    private void Energy_Flash(object? sender, EventArgs e)
    {
        if (flashedThisStep)
            return;

        flashedThisStep = true;
        Flash?.Invoke(null, EventArgs.Empty);
    }

    public void Initialise()
    {
        foreach (var neighbour in Neighbours)
            neighbour.Flash += Neighbour_Flash;
    }

    private void Neighbour_Flash(object? sender, EventArgs e) => IncrementEnergy();

    public void ResetRound() => flashedThisStep = false;

    public void Step() => IncrementEnergy();

    private void IncrementEnergy()
    {
        if (flashedThisStep)
            return;

        energy.Increment();
    }

    public override string ToString() => energy.ToString();
}
