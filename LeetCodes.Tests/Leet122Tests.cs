namespace LeetCodes.Tests;

using Xunit;

public class Leet122Tests
{
    private static readonly Leet122 Leet = new();

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] prices, int expected)
    {
        var actual = Leet.MaxProfit(prices);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<int[], int> Data()
    {
        var data = new TheoryData<int[], int>();
        foreach (var (prices, maxProfit) in Leet122.Data)
        {
            data.Add(prices, maxProfit);
        }

        return data;
    }
}
