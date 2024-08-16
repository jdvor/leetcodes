namespace LeetCodes;

public sealed class Leet274
{
    public int HIndex(int[] citations)
    {
        if (citations.Length == 0)
        {
            return 0;
        }

        Array.Sort(citations);
        Array.Reverse(citations);

        var hIndex = 0;
        for (var i = 0; i < citations.Length; i++)
        {
            if (citations[i] > i)
            {
                hIndex++;
            }
            else
            {
                return hIndex;
            }
        }

        return hIndex;
    }

    public static readonly (int[] citations, int hIndex)[] Data =
    [
        ([3,0,6,1,5], 3),
        ([1,3,1], 1),
        ([9,7,6,2,1], 3)
    ];
}
