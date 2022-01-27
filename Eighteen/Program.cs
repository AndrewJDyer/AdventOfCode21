using Eighteen;

var parser = new Parser(@"E:\Users\Heather\OneDrive\Andy\Code\AdventOfCode21\Eighteen\input.txt");
var allElements = parser.Parse().ToList();

Console.WriteLine(GetMaxMagniduteOfSummedPairs());

int GetMaxMagniduteOfSummedPairs()
{
    var max = 0;
    for (int i = 0; i < allElements.Count; i++)
    {
        for (int j = i + 1; j < allElements.Count; j++)
        {
            var maxSum = GetMaxSum(allElements[i], allElements[j]);
            if (maxSum > max)
                max = maxSum;
        }
    }
    return max;
}

int GetMaxSum(SnailfishPairElement x, SnailfishPairElement y)
{
    var sum = (x + y).GetMagnitude();
    var reverseSum = (y + x).GetMagnitude();
    return sum > reverseSum ? sum : reverseSum;
}
