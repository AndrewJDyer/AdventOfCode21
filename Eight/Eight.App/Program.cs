using Eight.Lib;

namespace Eight.App;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
            throw new InvalidOperationException("No path given");

        var path = args[0];
        var parser = new Parser.Parser(path);
        var display = parser.Parse();

        var calc = new Calculator(display);
        Console.WriteLine(calc.Count(1, 4, 7, 8));  //part 1
        Console.WriteLine(calc.SumOutputs());  //part 2
    }
}
