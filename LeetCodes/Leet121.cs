namespace LeetCodes;

public sealed class Leet121
{
    public int MaxProfit(int[] prices)
    {
        var profit = 0;
        var sell = prices[^1];
        for (var i = prices.Length - 2; i >= 0; i--)
        {
            profit = Math.Max(profit, sell - prices[i]);
            sell = Math.Max(sell, prices[i]);
        }

        return profit;
    }

    public static readonly (int[] prices, int maxProfix)[] Data =
    [
        ([7,1,5,3,6,4], 5),
        ([7,6,4,3,1], 0),
        ([5], 0),
    ];
}
