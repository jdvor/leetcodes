namespace LeetCodes.Tests;

using Xunit;

public class Leet217Tests
{
    private static readonly Leet217 Leet = new Leet217();

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int caseNo, int[] nums, bool expected)
    {
        var actual = Leet.ContainsDuplicate(nums);
        Assert.True(expected == actual, $"caseNo: {caseNo}, expected: {expected}, actual: {actual}");
    }

    public static IEnumerable<object[]> TestData()
    {
        foreach (var (caseNo, nums, expected) in Leet217.Data())
        {
            yield return new object[] { caseNo, nums, expected };
        }
    }
}
