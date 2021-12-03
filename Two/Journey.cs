namespace Two;

internal class Journey
{
    private int aim;

    public int HorizontalPos { get; private set; }
    public int Depth { get; private set; }

    public void AddCommand(Command command)
    {
        switch (command.Direction)
        {
            case Direction.Forward:
                HorizontalPos += command.Distance;
                Depth += aim * command.Distance;
                break;
            case Direction.Up:
                aim -= command.Distance;
                break;
            case Direction.Down:
                aim += command.Distance;
                break;
        }
    }
}
