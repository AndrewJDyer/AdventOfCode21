namespace Six;

internal class SpawnEventArgs : EventArgs
{
    public long Count { get; }

    public SpawnEventArgs(long count) => Count = count;

}
