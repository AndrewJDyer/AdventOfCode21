namespace Eleven;

internal class EnergyLevel
{
    private int value;

    public int Value => value;
    public event EventHandler? Flash;

    public EnergyLevel(int value) => this.value = value;

    public void Increment()
    {
        if (value != 9)
        {
            value++;
            return;
        }

        value = 0;
        Flash?.Invoke(null, EventArgs.Empty);
        return;
    }

    public override string ToString() => value.ToString();
}
