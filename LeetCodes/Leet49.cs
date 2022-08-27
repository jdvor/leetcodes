namespace LeetCodes;

using System.ComponentModel.Design;

/// <summary>
/// https://leetcode.com/problems/group-anagrams/
/// Given an array of strings strs, group the anagrams together. You can return the answer in any order.
/// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
/// typically using all the original letters exactly once.
/// </summary>
public sealed class Leet49
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        static string SortedByChar(string s)
        {
            var chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        var dict = new Dictionary<string, IList<string>>();
        foreach (var str in strs)
        {
            var sorted = str.Length > 1 ? SortedByChar(str) : str;
            if (dict.TryGetValue(sorted, out var lst))
            {
                lst!.Add(str);
            }
            else
            {
                dict.Add(sorted, new List<string> { str });
            }
        }

        return dict.Values.ToList();
    }

    public static (int CaseNo, string[] Strs, string[][] Result)[] Data()
    {
        var result1 = new[]
        {
            new[] { "bat" },
            new[] { "nat", "tan" },
            new[] { "ate", "eat", "tea" }
        };

        return new (int CaseNo, string[] Strs, string[][] Result)[]
        {
            (1, new[] { "eat", "tea", "tan", "ate", "nat", "bat" }, result1),
            (2, new[] { string.Empty }, new[] { Array.Empty<string>() }),
            (3, new[] { "a" }, new[] { new[] { "a" } }),
            (4, new[] { string.Empty, string.Empty }, new[] { new[] { string.Empty, string.Empty } }),
        };
    }
}
