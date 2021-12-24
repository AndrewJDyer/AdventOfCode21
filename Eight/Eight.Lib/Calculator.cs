using Eight.Parser;

namespace Eight.Lib;

public class Calculator
{
    private readonly IEnumerable<Display> displays;

    public Calculator(IEnumerable<Display> displays) => this.displays = displays;

    public int SumOutputs() => displays.Sum(EvalutateDisplay);

    private static int EvalutateDisplay(Display display) => new DisplayEvaluation(display).GetValue();

    public int Count(params int[] digitsToCount) => digitsToCount.Sum(Count);

    private int Count(int digitToCount) => displays.Sum(d => Count(d, digitToCount));

    private static int Count(Display display, int digitToCount) => display.OutputWords.Count(w => IsDigit(w, digitToCount));

    private static bool IsDigit(string word, int digit)
    {
        var possibleDigits = PossibleDigits(word);
        return possibleDigits.Count() == 1 && possibleDigits.Single() == digit;
    }

    private static IEnumerable<int> PossibleDigits(string word) =>
        new Dictionary<int, List<int>>()
        {
            { 2, new List<int>{ 1 } },
            { 3, new List<int> { 7 } },
            { 4, new List<int> { 4 } },
            { 5, new List<int> { 2, 3, 5 } },
            { 6, new List<int> { 0, 6, 9 } },
            { 7, new List<int> { 8 } }
        }[word.Length];
}
