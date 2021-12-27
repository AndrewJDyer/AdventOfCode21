// See https://aka.ms/new-console-template for more information
using Ten;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Ten\input.txt");
var part1Score = lines.Sum(l => new ChunkString(l).CalculateErrorScore());

Console.WriteLine(part1Score);

var part2Scores = lines.Select(l => new ChunkString(l).CalculateIncompleteScore()).Where(x => x != 0).ToList();
var index = part2Scores.Count / 2;
var part2Score = part2Scores.OrderBy(x => x).Skip(index).First();

Console.WriteLine(part2Score);
