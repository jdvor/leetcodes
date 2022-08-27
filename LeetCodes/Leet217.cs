namespace LeetCodes;

/// <summary>
/// https://leetcode.com/problems/contains-duplicate/
/// Given an integer array nums, return true if any value appears at least twice in the array,
/// and return false if every element is distinct.
/// </summary>
public sealed class Leet217
{
    /// <summary>
    /// my solution
    /// </summary>
    public bool ContainsDuplicate(int[] nums) {
        Array.Sort(nums);
        var prev = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            var curr = nums[i];
            if (curr == prev)
            {
                return true;
            }

            prev = curr;
        }

        return false;
    }

    public bool ContainsDuplicate2(int[] nums) {
        var hs = new HashSet<int>();
        foreach (var num in nums)
        {
            if (!hs.Add(num))
            {
                return true;
            }
        }

        return false;
    }

    public static (int CaseNo, int[] Nums, bool Result)[] Data()
    {
        return new[]
        {
            (1, new[] { 1, 2, 3, 1 }, true),
            (2, new[] { 1, 2, 3, 4 }, false),
            (3, new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)
        };
    }
}
