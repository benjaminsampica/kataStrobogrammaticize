using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Text;

static class BruteForce
{
    public static int GetStrobogrammaticNumbers(string firstVal, string secondVal)
    {
        double lowerBound = double.Parse(firstVal), upperBound = double.Parse(secondVal);
        var totalCount = 0;
        for (var i = lowerBound; i <= upperBound; i++) 
            if (IsStrobogrammaticNumber(i.ToString())) 
                totalCount++;
        return totalCount;
    }

    public static bool IsStrobogrammaticNumber(ReadOnlySpan<char> number)
    {
        if(InvalidDigits.IndexOfAny(number) > -1) return false;

        var span = new Span<char>(number.ToArray());
        for(var i = 0; i <= number.Length - 1; i++)
        {
            span[i] = ParseDigit(number[i]);
        }

        span.Reverse();

        return span.SequenceEqual(number);

        static char ParseDigit(char digit)
        {
            return digit switch
            {
                '6' => '9',
                '9' => '6',
                _ => digit
            };
        }
    }

    private static Span<char> InvalidDigits => new Span<char>(new[] { '2', '3', '4', '5', '7' });
}

[TestClass]
public class BruteForceGetStrobogrammaticNumbersTests
{
    [TestMethod]
    public void Given_0And0_ReturnsCountOf1() => BruteForce.GetStrobogrammaticNumbers("0", "0").Should().Be(1);

    [TestMethod]
    public void Given_0And1_ReturnsCountOf2() => BruteForce.GetStrobogrammaticNumbers("0", "1").Should().Be(2);

    [TestMethod]
    public void Given_0And25_ReturnsCountOf4() => BruteForce.GetStrobogrammaticNumbers("0", "25").Should().Be(4);

    [TestMethod]
    public void Given_100And1000_ReturnsCountOf12() => BruteForce.GetStrobogrammaticNumbers("100", "1000").Should().Be(12);
}