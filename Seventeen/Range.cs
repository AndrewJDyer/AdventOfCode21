namespace Seventeen;

internal record Range(int Lower, int Upper)
{
    public bool Contains(int value) => value >= Lower && value <= Upper;
}
