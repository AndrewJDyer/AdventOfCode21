using System.Collections;

namespace Three;

internal class Report : IReadOnlyList<BinaryNumber>
{
    private readonly IReadOnlyList<BinaryNumber> numbers;

    public int Length => numbers.Max(x => x.Count);
    public int Count => numbers.Count;

    public BinaryNumber this[int index] => numbers[index];

    public Report(IEnumerable<BinaryNumber> numbers) => this.numbers = numbers.ToList();

    public IEnumerator<BinaryNumber> GetEnumerator() => numbers.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)numbers).GetEnumerator();
}
