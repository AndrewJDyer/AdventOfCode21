using Fifteen;

var parser = new Parser(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Fifteen\input.txt");
var map = new CaveMap(parser.Parse());
var pathFinder = new DijkstraPathFinder(map);

Console.WriteLine(pathFinder.FindShortestPathLength());
