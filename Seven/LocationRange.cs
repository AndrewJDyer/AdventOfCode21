namespace Seven;

class LocationRange
{
    public CrabLocation Upper { get; }
    public CrabLocation Lower { get; }

    private LocationRange(CrabLocation lower, CrabLocation upper)
    {
        Lower = lower;
        Upper = upper;
    }

    public static LocationRange FromSet(LocationSet set)
    {
        CrabLocation? upper = null;
        CrabLocation? lower = null;
        foreach (var location in set)
        {
            if (upper is null)
                upper = location;
            else
                upper = upper > location ? upper : location;

            if (lower is null)
                lower = location;
            else
                lower = lower < location ? lower : location;
        }

        if (lower is null || upper is null)
            throw new InvalidOperationException("No locations!");

        return new(lower, upper);
    }
}