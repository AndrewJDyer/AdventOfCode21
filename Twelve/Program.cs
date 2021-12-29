using Twelve;

var parser = new Parser(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Twelve\input.txt");
var caveSystem = parser.Parse();

Console.WriteLine(caveSystem.CountRoutesToEnd());
