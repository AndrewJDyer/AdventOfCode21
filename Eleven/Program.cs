// See https://aka.ms/new-console-template for more information
using Eleven;

var parser = new Parser(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Eleven\input.txt");
var initialEnergies = parser.Parse();
var counter = new FlashCounter(new (initialEnergies), 100);
var part1Answer = counter.Count();

Console.WriteLine(part1Answer);

var syncNotifier = new SyncNotifier(new(initialEnergies));
var part2Answer = syncNotifier.GetRoundOfFirstSync();

Console.WriteLine(part2Answer);

