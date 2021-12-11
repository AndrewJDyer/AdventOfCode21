namespace Seven;

class CrabLocation
{
    private readonly int value;

    public CrabLocation(int value) => this.value = value;

    public CrabLocation(CrabLocation other) : this(other.value) { }

    public int FuelTo(CrabLocation other) => Math.Abs(this.value - other.value);

    public static bool operator <(CrabLocation x, CrabLocation y) => x.value < y.value;
    public static bool operator >(CrabLocation x, CrabLocation y) => x.value > y.value;
    public static bool operator <=(CrabLocation x, CrabLocation y) => x.value <= y.value;
    public static bool operator >=(CrabLocation x, CrabLocation y) => x.value >= y.value;
    public static CrabLocation operator +(CrabLocation x, CrabLocation y) => new(x.value + y.value);
    public static CrabLocation operator ++(CrabLocation x) => new(x.value + 1);
}