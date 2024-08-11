namespace LeetCodes;

/// <summary>
/// https://leetcode.com/problems/filling-bookcase-shelves/description
/// https://www.youtube.com/watch?v=lFYPPPTp8qE
/// </summary>
public sealed class Leet1105
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        if (books.Length == 0)
        {
            return 0;
        }

        var memo = new Dictionary<int, int>(books.Length);
        return Calc(0);

        int Calc(int index)
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
                result = Math.Min(result, maxHeight + Calc(index + 1));
                memo[index] = result;
            }

            return result;
        }
    }

    public static readonly (int[][] books, int shelfWidth, int minShelfHeight)[] Data =
    [
        ([[1,1], [2,3], [2,3], [1,1], [1,1], [1,1], [1,2]], 4, 6),
        ([[1,3], [2,4], [3,2]], 6, 4),
        ([], 5, 0)
    ];
}
