// See https://aka.ms/new-console-template for more information
using Ten;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Ten\input.txt");
var scoreSum = lines.Sum(l => new ChunkString(l).CalculateErrorScore());

Console.WriteLine(scoreSum);
