// See https://aka.ms/new-console-template for more information
using Five;

Console.WriteLine("Hello, World!");

var vents = new InputParser(@"E:\Users\Heather\OneDrive\Andy\Code\AdventOfCode21\Five\input.txt").Parse();
var intersectionCount = new IntersectionCounter(vents).CountIntersections();

Console.WriteLine(intersectionCount);
