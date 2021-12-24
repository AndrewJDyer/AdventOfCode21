namespace Eight.Lib;

internal class WordTranslator
{
    private readonly Word word;
    private readonly PotentialWordMappings mapping;

    public WordTranslator(Word word, PotentialWordMappings mapping)
    {
        this.word = word;
        this.mapping = mapping;
    }

    public int Translate() => mapping.GetValue(word).Value;
}
