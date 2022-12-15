namespace LeetCodes.Tests;

using Xunit;

public class Leet8Tests
{
    private static readonly Leet8 Leet = new Leet8();

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, int expected)
    {
        var actual = Leet.MyAtoi(s);
        Assert.True(expected == actual, $"s: '{s}', expected: {expected}, actual: {actual}");
    }

    public static IEnumerable<object[]> TestData()
    {
        foreach (var (s, n) in Leet8.Data)
        {
            yield return new object[] { s, n };
        }
    }
}
