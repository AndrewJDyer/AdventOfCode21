// See https://aka.ms/new-console-template for more information
using Six;

Console.WriteLine("Hello, World!");

var initialFishes = new InputParser(@"C:\projects\AdventOfCode21\Six\input.txt").Parse();

var model = new OceanModel(initialFishes);

var tracker = new FishTracker(model);
tracker.IncrementDays(256);
Console.WriteLine(tracker.CountFishes());

