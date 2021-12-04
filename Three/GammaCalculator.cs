namespace Three;

internal class GammaCalculator : ITemplateGenerator
{
    private readonly IReadOnlyList<BinaryNumber> report;

    public GammaCalculator(IEnumerable<BinaryNumber> report) => this.report = report.ToList();

    public BinaryNumber GetTemplate()
    {
        var length = GetLength();
        var array = new bool[length];
        for (int i = 0; i < length; i++)
            array[i] = CalculateBit(i);

        return new(array);
    }

    private bool CalculateBit(int index)
    {
        var zerosCount = 0;
        var onesCount = 0;
        foreach (var num in report)
        {
            if (num.Count <= index)
                continue;

            if (num[index])
                onesCount++;
            else
                zerosCount++;
        }

        return onesCount >= zerosCount;
    }

    private int GetLength() => report.Max(x => x.Count);
}
