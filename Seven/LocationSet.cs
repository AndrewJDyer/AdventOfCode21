using System.Collections;

namespace Seven;

class LocationSet : IEnumerable<CrabLocation>
{
    private readonly IEnumerable<CrabLocation> locations;

    public LocationSet(IEnumerable<int> values) => locations = values.Select(x => new CrabLocation(x));

    public IEnumerator<CrabLocation> GetEnumerator() => locations.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)locations).GetEnumerator();
}