using Eight.Parser;
using NUnit.Framework;
using System.Collections.Generic;

namespace Eight.Lib.Test;

public class CalculatorTest
{
    [TestCase("ab", 1, ExpectedResult = 1)]
    [TestCase("bg", 1, ExpectedResult = 1)]
    [TestCase("ab", 4, ExpectedResult = 0)]

    [TestCase("abc", 7, ExpectedResult = 1)]
    [TestCase("bfg", 7, ExpectedResult = 1)]
    [TestCase("abc", 1, ExpectedResult = 0)]

    [TestCase("abcd", 4, ExpectedResult = 1)]
    [TestCase("bdfg", 4, ExpectedResult = 1)]
    [TestCase("abcd", 1, ExpectedResult = 0)]

    [TestCase("abcdefg", 8, ExpectedResult = 1)]
    [TestCase("abcdefg", 1, ExpectedResult = 0)]
    public int Count_SingleWord(string word, params int[] digitsToCount)
    {
        var display = new Display(new[] { word }, new[] { word });
        var displays = new[] { display };
        var calc = new Calculator(displays);

        return calc.Count(digitsToCount);
    }

    [TestCase("bdfeagc degcf adegb gcdbe ebc dfgbce degafc fbgc dbafec bc", "degfc gdbec degfc decbg", ExpectedResult = 5353)]
    [TestCase("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab", "cdfeb cdfeb fcadb cdbaf", ExpectedResult = 5533)]
    [TestCase("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab", "cdfeb fcadb cdfeb cdbaf", ExpectedResult = 5353)]
    public int SumOutputs_SingleDisplay(string inputs, string outputs)
    {
        var display = new Display(inputs.Split(' '), outputs.Split(' '));
        var displays = new[] { display };
        var calc = new Calculator(displays);

        return calc.SumOutputs();
    }
}
