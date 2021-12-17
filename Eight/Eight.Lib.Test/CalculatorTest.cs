using Eight.Parser;
using NUnit.Framework;
using System.Collections.Generic;

namespace Eight.Lib.Test;

public class CalculatorTest
{
    [SetUp]
    public void Setup()
    {
    }

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
    public int SingleWord(string word, params int[] digitsToCount)
    {
        var display = new Display(new[] { word }, new[] { word });
        var displays = new[] { display };
        var calc = new Calculator(displays);

        return calc.Count(digitsToCount);
    }

    private IEnumerable<string> GetWordCollection(params string[] words) => words;
}
