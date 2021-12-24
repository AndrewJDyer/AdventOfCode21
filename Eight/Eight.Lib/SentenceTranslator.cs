namespace Eight.Lib;

internal class SentenceTranslator
{
    private readonly Lazy<int> value;
    private readonly IEnumerable<string> inputWords;
    private readonly IReadOnlyList<string> outputWords;
    private readonly PotentialWordMappings wordMappings = new();
    private int runningTotal;

    public int Value => value.Value;

    public SentenceTranslator(IEnumerable<string> inputWords, IEnumerable<string> outputWords)
    {
        value = new(Translate);
        this.inputWords = inputWords;
        this.outputWords = outputWords.ToList();
    }

    private int Translate()
    {
        foreach (var word in inputWords)
            wordMappings.RegisterWord(new(word));

        for (int i = 1; i <= outputWords.Count; i++)
            AddWordValue(new(outputWords[i - 1]), outputWords.Count - i);

        return runningTotal;
    }

    private void AddWordValue(Word word, int index)
    {
        var wordValue = new WordTranslator(word, wordMappings).Translate();
        var multiplier = GetMultiplier(index);

        runningTotal += wordValue * multiplier;
    }

    private static int GetMultiplier(int index)
    {
        var multiplier = 1;
        for (int i = 0; i < index; i++)
            multiplier *= 10;

        return multiplier;
    }
}
