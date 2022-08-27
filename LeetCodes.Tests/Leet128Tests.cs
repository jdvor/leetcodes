namespace LeetCodes.Tests;

using Xunit;

public class Leet128Tests
{
    private static readonly Leet128 Leet = new Leet128();

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int caseNo, int[] nums, int expected)
    {
        var actual = Leet.LongestConsecutive(nums);
        Assert.True(expected == actual, $"caseNo: {caseNo}, expected: {expected}, actual: {actual}");
    }

    [Fact]
    public void Test1()
    {
        var nums = new[] { 9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6 };
        var actual = Leet.LongestConsecutive(nums);
        Assert.Equal(7, actual);
    }

    public static IEnumerable<object[]> TestData()
    {
        foreach (var (caseNo, nums, expected) in Leet128.Data())
        {
            yield return new object[] { caseNo, nums, expected };
        }
    }
}
