// See https://aka.ms/new-console-template for more information
using Seven;

Console.WriteLine("Hello, World!");

var inputs = InputParser.Parse(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Seven\input.txt");
var set = new LocationSet(inputs);
var destinationSelector = new DestinationSelector(set);
var (_, fuel) = destinationSelector.Select();

Console.WriteLine(fuel);
