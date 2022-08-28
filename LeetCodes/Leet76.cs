namespace LeetCodes;

using System.Runtime.CompilerServices;
using System.Text;

// ReSharper disable InvalidXmlDocComment
/// <summary>
/// 76. Minimum Window Substring
/// https://leetcode.com/problems/minimum-window-substring/
///
/// Given two strings s and t of lengths m and n respectively, return the minimum window substring of s
/// such that every character in t (including duplicates) is included in the window.
/// If there is no such substring, return the empty string "".
/// The testcases will be generated such that the answer is unique.
/// A substring is a contiguous sequence of characters within the string.
///
/// Constraints:
/// 1 <= m, n <= 105
/// s and t consist of uppercase and lowercase English letters.
/// </summary>
public sealed class Leet76
{
    public string MinWindow(string s, string t)
    {
        var m = s.Length;
        var n = t.Length;
        if (n > m)
        {
            return string.Empty;
        }

        var needleFreq = new int[AllChars];
        CalcFreq(t, needleFreq);

        //var ns = needleFreq.Describe();

        var windowSize = n;
        var windowFreq = new int[AllChars];

        while (windowSize <= m)
        {
            var window = s.AsSpan()[..windowSize];
            CalcFreq(window, windowFreq);

            //var ws = windowFreq.Describe();

            if (ContainsFreq(windowFreq, needleFreq))
            {
                return window.ToString();
            }

            for (var i = windowSize; i < m; i++)
            {
                var rem = s[i - windowSize];
                var add = s[i];
                var remIdx = FreqIdx(rem);
                var addIdx = FreqIdx(add);
                --windowFreq[remIdx];
                ++windowFreq[addIdx];

                //ws = windowFreq.Describe();

                if (ContainsFreq(windowFreq, needleFreq))
                {
                    return s.Substring(i - windowSize + 1, windowSize);
                }
            }

            ++windowSize;
        }

        return string.Empty;
    }

    public string MinWindow2(string s, string t)
    {
        if (t.Length > s.Length)
        {
            return string.Empty;
        }

        int idx;

        // calculate needle (t) char frequency
        var needleFreq = new int[AllChars];
        foreach (var ch in t)
        {
            idx = FreqIdx(ch);
            ++needleFreq[idx];
        }

        // calculate char frequency in minimal viable window of s (0 .. t.Length)
        var windowFreq = new int[AllChars];
        for (var i = 0; i < t.Length; i++)
        {
            idx = FreqIdx(s[i]);
            ++windowFreq[idx];
        }

        for (var right = t.Length; right < s.Length; right++)
        {
            if (ContainsFreq(windowFreq, needleFreq))
            {
                int left;
                for (left = 0; left < right; left++)
                {
                    // shrinks window from left
                    idx = FreqIdx(s[left]);
                    --windowFreq[idx];

                    if (!ContainsFreq(windowFreq, needleFreq))
                    {
                        break;
                    }
                }

                return s.Substring(left, right - left);
            }

            // expands window to right
            idx = FreqIdx(s[right]);
            ++windowFreq[idx];
        }

        return string.Empty;
    }

    public const int LowerAscii = 'a'; // 97
    public const int UpperAscii = 'A'; // 65
    public const int Alphabet = 26;
    private const int AllChars = 2 * Alphabet;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int FreqIdx(char ch)
    {
        // <a .. z A .. Z> => <0 .. 25 26 .. 51>
        int idx = ch;
        return idx >= LowerAscii
            ? idx - LowerAscii
            : idx - UpperAscii + Alphabet;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void CalcFreq(ReadOnlySpan<char> segment, int[] freq)
    {
        Array.Fill(freq, 0);
        foreach (var ch in segment)
        {
            var idx = FreqIdx(ch);
            ++freq[idx];
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool ContainsFreq(int[] left, int[] right)
    {
        for (var i = 0; i < AllChars; i++)
        {
            if (left[i] < right[i])
            {
                return false;
            }
        }

        return true;
    }

    public static readonly (int caseNo, string s, string t, string mws)[] Data = {
        (1, "ADOBECODEBANC", "ABC", "BANC"),
        (2, "a", "a", "a"),
        (3, "a", "aa", string.Empty),
        (4, "aaabbbcccdddeee", "dcbc", "bcccd"),
    };
}

public static class ArrayExtensions
{
    public static string Describe(this int[] arr)
    {
        var sb = new StringBuilder();
        var first = true;
        for (var i = 0; i < arr.Length; i++)
        {
            var v = arr[i];
            if (v <= 0)
            {
                continue;
            }

            if (first)
            {
                first = false;
            }
            else
            {
                sb.Append(", ");
            }

            var ch = (char)(i >= Leet76.Alphabet ? i - Leet76.Alphabet + Leet76.UpperAscii : i + Leet76.LowerAscii);
            sb.Append($"{ch}: {v}");
        }

        return sb.ToString();
    }
}
