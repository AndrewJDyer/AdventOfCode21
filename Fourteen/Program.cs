using Fourteen;

var parser = new Parser(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Fourteen\input.txt");
var polymer = parser.Parse();

polymer.RunRules(10);

var elementCounts = polymer.ElementCounts;
var mostCommonElement = elementCounts.Max(kvp => kvp.Value);
var leastCommonElement = elementCounts.Min(kvp => kvp.Value);

Console.WriteLine(mostCommonElement - leastCommonElement);
