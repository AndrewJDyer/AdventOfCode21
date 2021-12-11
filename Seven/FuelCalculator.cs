namespace Seven;

class FuelCalculator
{
    private readonly LocationSet locations;

    public FuelCalculator(LocationSet locations) => this.locations = locations;

    public int GetFuelTo(CrabLocation proposedDestination) => locations.Sum(x => x.FuelTo(proposedDestination));
}