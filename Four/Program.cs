// See https://aka.ms/new-console-template for more information
using Four;

Console.WriteLine("Hello, World!");

var input = new InputParser(@"input.txt").Parse();
var drawmaster = new Drawmaster(input.Sequence, input.Boards);
drawmaster.RunGame();

Console.WriteLine(drawmaster.LosingScore);
