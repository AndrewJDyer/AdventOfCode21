namespace Sixteen;

internal class Header
{
    public int Version { get; }
    public TypeId TypeId { get; }
    public bool IsLiteral => TypeId == TypeId.Literal;
    public bool IsOperator => !IsLiteral;

    public Header(bool[] bits)
    {
        Version = ConvertVersion(bits[..3]);
        TypeId = ConvertType(bits[3..]);
    }

    private static int ConvertVersion(bool[] versionBits)
        => (int)new IntConversion(versionBits).Convert();

    private static TypeId ConvertType(bool[] typeBits)
        => (TypeId)new IntConversion(typeBits).Convert();
}
