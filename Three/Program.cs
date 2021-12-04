// See https://aka.ms/new-console-template for more information
using Three;

Console.WriteLine("Hello, World!");

var parser = new InputFileParser(@"..\..\..\Input.txt");
var report = parser.Parse();

var oxygenRating = new RatingCalculator(report, new GammaCalculatorFactory()).Calculate();
var co2Rating = new RatingCalculator(report, new EpsilonDecoratorFactory()).Calculate();

var result = oxygenRating * co2Rating;
Console.WriteLine(result);
