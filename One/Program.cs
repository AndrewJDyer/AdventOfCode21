using System;

namespace One
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var parser = new InputFileParser(@"C:\projects\AdventOfCode21\One\input.txt");
            var sweep = new SonarSweep(parser.ParseSets());
            Console.WriteLine(sweep.CountIncreases());
        }
    }
}