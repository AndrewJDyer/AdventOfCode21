using System.Collections;

namespace Four;

internal class DrawSequence : IEnumerable<int>
{
    private readonly IEnumerable<int> sequence;

    public DrawSequence(IEnumerable<int> sequence) => this.sequence = sequence;

    public IEnumerator<int> GetEnumerator() => sequence.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)sequence).GetEnumerator();
}
