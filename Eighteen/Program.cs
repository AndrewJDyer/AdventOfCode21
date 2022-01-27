using Eighteen;

var parser = new Parser(@"E:\Users\Heather\OneDrive\Andy\Code\AdventOfCode21\Eighteen\input.txt");
var allPairs = parser.Parse();

var total = allPairs.Sum();
var magnitude = total.GetMagnitude();

Console.WriteLine(magnitude);
