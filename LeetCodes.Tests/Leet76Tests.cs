namespace LeetCodes.Tests;

using Xunit;

public class Leet76Tests
{
    private static readonly Leet76 Leet = new Leet76();

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int caseNo, string s, string t, string expected)
    {
        var actual = Leet.MinWindow2(s, t);
        Assert.True(expected == actual, $"caseNo: {caseNo}, expected: {expected}, actual: {actual}");
    }

    [Fact]
    public void Test1()
    {
        var mws = Leet.MinWindow2("ADOBECODEBANC", "ABC");
    }

    public static IEnumerable<object[]> TestData()
    {
        foreach (var (caseNo, s, t, mws) in Leet76.Data)
        {
            yield return new object[] { caseNo, s, t, mws };
        }
    }
}
