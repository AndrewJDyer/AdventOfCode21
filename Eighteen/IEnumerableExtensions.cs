namespace Eighteen;

internal static class IEnumerableExtensions
{
    public static SnailfishPairElement Sum(this IEnumerable<SnailfishPairElement> elements)
    {
        var list = elements.ToList();
        if (list.Count == 0)
            throw new ArgumentException("No elements");

        var total = list[0];
        for (int i = 1; i < list.Count; i++)
            total += list[i];

        return total;
    }
}
