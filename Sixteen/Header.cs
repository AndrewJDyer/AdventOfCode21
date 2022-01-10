namespace Sixteen;

internal class Header
{
    private const int LiteralTypeId = 4;

    public int Version { get; }
    public int TypeId { get; }
    public bool IsLiteral => TypeId == LiteralTypeId;
    public bool IsOperator => !IsLiteral;

    public Header(bool[] bits)
    {
        Version = new IntConversion(bits[..3]).Convert();
        TypeId = new IntConversion(bits[3..]).Convert();
    }
}
