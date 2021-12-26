// See https://aka.ms/new-console-template for more information
using Nine;

Console.WriteLine("Hello, World!");

var heights = new Parser(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Nine\input.txt").Parse();
var map = new Map(heights);
var part1Answer = new RiskEvaluator(map).SumRisks();
var part2Answer = new BasinCollator(map).MultiplyThreeLargestBasinSizes();

Console.WriteLine(part1Answer);
Console.WriteLine(part2Answer);
