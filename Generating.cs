using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

static class Generating
{
    public static double GetStrobogrammaticNumbers(string firstVal, string secondVal) 
    { 
        int firstLength = firstVal.Length, secondLength = secondVal.Length; 
        double firstValueAsDouble = double.Parse(firstVal), secondValueAsDouble = double.Parse(secondVal); 
        var results = new List<string>(); 

        for (int i = firstLength; i <= secondLength; i++) 
        { 
            results.AddRange(GetStrobogrammaticStrings(i, i)); 
        } 

        var count = CountResults(); 

        return count; 
        
        int CountResults() 
        { 
            var count = 0; 
            foreach (var number in results) 
            { 
                var numberAsDouble = double.Parse(number); 

                var length = number.Length; if (length == firstLength && numberAsDouble < firstValueAsDouble) continue; 
                if (length == secondLength && numberAsDouble > secondValueAsDouble) continue; 

                count++; 
            } 
            return count; 
        } 
    }

    private static IEnumerable<string> GetStrobogrammaticStrings(int positionedVarianceLength, int originalVarianceLength) 
    { 
        if (positionedVarianceLength == 0) 
        { 
            yield return null; 
            yield break; 
        } 
        if (positionedVarianceLength == 1) 
        { 
            yield return "0"; 
            yield return "1";
            yield return "8"; 
            yield break; 
        } 
        var innerStrobogrammaticNumbers = GetStrobogrammaticStrings(positionedVarianceLength - 2, originalVarianceLength); 
        foreach (var numberSet in innerStrobogrammaticNumbers) 
        { 
            if (positionedVarianceLength != originalVarianceLength) 
                yield return $"0{numberSet}0"; 
            yield return $"8{numberSet}8"; 
            yield return $"1{numberSet}1"; 
            yield return $"6{numberSet}6"; 
            yield return $"9{numberSet}9"; 
        } 
    }
}

[TestClass]
public class GeneratingGetStrobogrammaticNumbersTests
{
    [TestMethod]
    public void Given_0And0_ReturnsCountOf1() => Generating.GetStrobogrammaticNumbers("0", "0").Should().Be(1);

    [TestMethod]
    public void Given_0And1_ReturnsCountOf2() => Generating.GetStrobogrammaticNumbers("0", "1").Should().Be(2);

    [TestMethod]
    public void Given_0And25_ReturnsCountOf4() => Generating.GetStrobogrammaticNumbers("0", "25").Should().Be(4);

    [TestMethod]
    public void Given_100And1000_ReturnsCountOf12() => Generating.GetStrobogrammaticNumbers("100", "1000").Should().Be(12);
}


