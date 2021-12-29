using Thirteen;

var parser = new Parser(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Thirteen\input.txt");
var (sheet, instructions) = parser.Parse();

foreach (var fold in instructions)
{
    sheet.DoFold(fold);
    Console.WriteLine(sheet);
    Console.WriteLine("-------------------------------------------------------------------------------------------");
}
