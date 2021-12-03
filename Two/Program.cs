// See https://aka.ms/new-console-template for more information
using Two;

Console.WriteLine("Hello, World!");

var journey = new Journey();
var commands = new InputFileParser(@"..\..\..\InputFile.txt").Parse();
foreach (var command in commands)
    journey.AddCommand(command);

var result = journey.HorizontalPos * journey.Depth;
Console.WriteLine(result);
