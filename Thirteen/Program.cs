using Thirteen;

var parser = new Parser(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Thirteen\input.txt");
var (sheet, instructions) = parser.Parse();
sheet.DoFold(instructions[0]);

Console.WriteLine(sheet.Dots);
