namespace LeetCodes.Tests;

using Xunit;

public class Leet274Tests
{
    private static readonly Leet274 Leet = new();

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] citations, int expected)
    {
        var actual = Leet.HIndex(citations);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<int[], int> Data()
    {
        var data = new TheoryData<int[], int>();
        foreach (var (citations, hIndex) in Leet274.Data)
        {
            data.Add(citations, hIndex);
        }

        return data;
    }
}
