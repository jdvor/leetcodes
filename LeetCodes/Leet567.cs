namespace LeetCodes;

using System.ComponentModel.Design;
using System.Text;

/// <summary>
/// https://leetcode.com/problems/permutation-in-string/
/// Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
/// In other words, return true if one of s1's permutations is the substring of s2.
/// </summary>
public sealed class Leet567
{
    public bool CheckInclusion(string s1, string s2)
    {
        var needleLen = s1.Length;
        var haystackLen = s2.Length;
        if (needleLen > haystackLen)
        {
            return false;
        }

        const int zero = 'a';
        const int charCnt = 26;

        var needleFreq = new int[charCnt];
        var windowFreq = new int[charCnt];
        for (var i = 0; i < needleLen; i++)
        {
            ++needleFreq[s1[i] - zero];
            ++windowFreq[s2[i] - zero];
        }

        int m;
        for (m = 0; m < charCnt; m++)
        {
            if (needleFreq[m] != windowFreq[m])
            {
                break;
            }
        }

        if (m == charCnt)
        {
            return true;
        }

        if (needleLen == haystackLen)
        {
            return false;
        }

        for (var i = needleLen; i < haystackLen; i++)
        {
            var remIdx = s2[i - needleLen] - zero;
            var addIdx = s2[i] - zero;
            --windowFreq[remIdx];
            ++windowFreq[addIdx];
            for (m = 0; m < charCnt; m++)
            {
                if (needleFreq[m] != windowFreq[m])
                {
                    break;
                }
            }

            if (m == charCnt)
            {
                return true;
            }
        }

        return false;
    }

    public static readonly (int CaseNo, string s1, string s2, bool expected)[] Data = {
        (1, "ab", "eidbaooo", true),
        (2, "ab", "eidboaoo", false),
        (3, "a", "ab", true),
    };
}
