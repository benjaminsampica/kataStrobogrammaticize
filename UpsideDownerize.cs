using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

static class Kata
{
    public static int GetUpsideDownableNumbers(string firstVal, string secondVal)
    {
        return 1;
    }
}

[TestClass]
public class GetUpsideDownableNumbersTests
{
    [TestMethod]
    public void Given_ZeroAndZero_ReturnsCountOfOne() => Kata.GetUpsideDownableNumbers("0", "0").Should().Be(1);


}