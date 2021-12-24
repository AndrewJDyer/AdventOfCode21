using Eight.Parser;

namespace Eight.Lib;

internal class DisplayEvaluation
{
    private readonly Display display;

    public DisplayEvaluation(Display display) => this.display = display;

    public int GetValue() => new SentenceTranslator(display.InputWords, display.OutputWords).Value;
}
