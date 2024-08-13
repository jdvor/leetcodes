namespace LeetCodes;

/// <summary>
/// https://leetcode.com/problems/filling-bookcase-shelves/description
/// https://www.youtube.com/watch?v=lFYPPPTp8qE
/// </summary>
public sealed class Leet1105
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        var n = books.Length;
        Span<int> dp = stackalloc int[n + 1];
        dp.Fill(int.MaxValue);
        dp[0] = 0;

        for(var i = 0; i < books.Length; i ++)
        {
            var sumThickness = 0;
            var maxHeight = 0;

            for(var j = i; j >= 0; j--)
            {
                var thickness = books[j][0];
                var height = books[j][1];
                sumThickness += thickness;

                if(sumThickness > shelfWidth)
                    break;

                maxHeight = Math.Max(maxHeight, height);
                dp[i + 1] = Math.Min(dp[i + 1], dp[j] + maxHeight);
            }
        }

        return dp[n];
    }

    public int MinHeightShelvesRecursive(int[][] books, int shelfWidth)
    {
        if (books.Length == 0)
        {
            return 0;
        }

        var memo = new Dictionary<int, int>(books.Length);
        return CalculateRecursive(0, memo, books, shelfWidth);
    }

    private static int CalculateRecursive(int index, Dictionary<int, int> memo, int[][] books, int shelfWidth)
    {
        if (index == books.Length)
        {
            return 0;
        }

        if (memo.TryGetValue(index, out var result))
        {
            return result;
        }

        var remainingShelfWidth = shelfWidth;
        var maxHeight = 0;
        result = int.MaxValue;
        for (var j = index; j < books.Length; j++)
        {
            var width = books[j][0];
            var height = books[j][1];
            if (width > remainingShelfWidth)
            {
                break;
            }

            remainingShelfWidth -= width;
            maxHeight = Math.Max(maxHeight, height);
            result = Math.Min(result, maxHeight + CalculateRecursive(j + 1, memo, books, shelfWidth));
            memo[index] = result;
        }

        return result;
    }

    public static readonly (string name, int[][] books, int shelfWidth, int minShelfHeight)[] Data =
    [
        ("1", [[1,1], [2,3], [2,3], [1,1], [1,1], [1,1], [1,2]], 4, 6),
        ("2", [[1,3], [2,4], [3,2]], 6, 4),
        ("empty", [], 5, 0)
    ];
}
