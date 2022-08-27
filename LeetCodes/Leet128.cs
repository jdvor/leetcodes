namespace LeetCodes;

/// <summary>
/// https://leetcode.com/problems/longest-consecutive-sequence/
/// Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
/// You must write an algorithm that runs in O(n) time.
///
/// The description is quite misleading; see case no. 6.
/// Given the test cases I think this would be much better description:
/// What is the longest consecutive sequence that you can create from input numbers (nums).
/// </summary>
public sealed class Leet128
{
    /// <summary>
    /// possible optimization: if remaining array length could not beat current max even if consecutive => return early.
    /// </summary>
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0)
        {
            return 0;
        }

        Array.Sort(nums);
        var len = 1;
        var max = 1;
        var prev = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            var curr = nums[i];
            if (curr == prev)
            {
                continue;
            }
            if (curr == prev + 1)
            {
                ++len;
            }
            else
            {
                if (len > max)
                {
                    max = len;
                }

                len = 1;
            }

            prev = curr;
        }

        if (len > max)
        {
            max = len;
        }

        return max;
    }

    public static (int CaseNo, int[] Nums, int Result)[] Data()
    {
        return new[]
        {
            (1, Array.Empty<int>(), 0),
            (2, new[] { 0 }, 1),
            (3, new[] { 100, 4, 200, 1, 3, 2 }, 4), // [1, 2, 3, 4, 100, 200] = 4
            (4, new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9), // [0, 0, 1, 2, 3, 4, 5, 6, 7, 8] = 9
            (5, new[] { 9, 1, 4, 7, 3, -1, 0, 5 ,8, -1, 6 }, 7), // [-1, -1, 0, 1, 3, 4, 5, 6, 7, 8, 9] = 7
            (6, new[] { 1, 2, 0, 1 }, 3), // [0, 1, 1, 2] = 3
        };
    }
}
