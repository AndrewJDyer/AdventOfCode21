namespace Seven;

class DestinationSelector
{
    private readonly LocationSet set;
    private readonly FuelCalculator fuelCalc;

    public DestinationSelector(LocationSet locations)
    {
        set = locations;
        fuelCalc = new(locations);
    }

    public (CrabLocation Location, int Fuel) Select()
    {
        var range = LocationRange.FromSet(set);
        LocationCandidate? candidate = null;
        for (var i = range.Lower; i <= range.Upper; i++)
        {
            var fuel = fuelCalc.GetFuelTo(i);
            if (candidate is null || candidate.Fuel > fuel)
                candidate = new(i, fuelCalc.GetFuelTo(i));
        }

        if (candidate is null)
            throw new InvalidOperationException("No locations");

        return (candidate, candidate.Fuel);
    }

    private class LocationCandidate : CrabLocation
    {
        public int Fuel { get; }

        public LocationCandidate(CrabLocation location, int fuel)
            : base(location) => Fuel = fuel;
    }
}