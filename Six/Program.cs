// See https://aka.ms/new-console-template for more information
using Six;

Console.WriteLine("Hello, World!");

var initialFishes = new InputParser(@"E:\Users\Heather\OneDrive\Andy\Code\AdventOfCode21\Six\input.txt").Parse();
var tracker = new FishTracker(initialFishes);
tracker.IncrementDays(80);
Console.WriteLine(tracker.CountFishes());

