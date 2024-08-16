namespace LeetCodes;

public sealed class Leet122
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length < 2)
        {
            return 0;
        }

        var profit = 0;
        var buy = prices[0];
        for (var i = 1; i < prices.Length; i++)
        {
            var sell = prices[i];
            if (sell > buy)
            {
                profit += sell - buy;
            }

            buy = sell;
        }

        return profit;
    }

    public static readonly (int[] prices, int maxProfix)[] Data =
    [
        ([7,1,5,3,6,4], 7),
        ([1,2,3,4,5], 4),
        ([7,6,4,3,1], 0),
        ([5], 0),
    ];
}
