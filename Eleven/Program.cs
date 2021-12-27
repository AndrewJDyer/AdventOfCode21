// See https://aka.ms/new-console-template for more information
using Eleven;

var parser = new Parser(@"C:\Users\hapdy\OneDrive\Andy\Code\AdventOfCode21\Eleven\input.txt");
var cavern = new Cavern(parser.Parse());
var counter = new FlashCounter(cavern, 100);
var count = counter.Count();

Console.WriteLine(count);
