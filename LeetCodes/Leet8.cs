namespace LeetCodes;

/// <summary>
/// https://leetcode.com/problems/string-to-integer-atoi/
/// </summary>
public sealed class Leet8
{
    public int MyAtoi(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        var positive = true;
        var nonSpaceRead = false;
        int result = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            if (!char.IsDigit(ch))
            {
                if (nonSpaceRead)
                {
                    return positive ? result : -result;
                }

                switch (ch)
                {
                    case ' ':
                        continue;
                    case '+':
                        nonSpaceRead = true;
                        continue;
                    case '-':
                        nonSpaceRead = true;
                        positive = false;
                        continue;
                }

                return positive ? result : -result;
            }

            nonSpaceRead = true;
            var n = (int)char.GetNumericValue(ch);
            checked
            {
                try
                {
                    result = result * 10 + n;
                }
                catch (OverflowException)
                {
                    return positive ? int.MaxValue : int.MinValue;
                }
            }
        }

        return positive ? result : -result;
    }

    public static readonly (string s, int n)[] Data =
    {
        ("42", 42),
        ("-42", -42),
        ("4193 with words", 4193),
        ("  43", 43),
        (" -43", -43),
        ("0032", 32),
        ("00320", 320),
        ("-00320", -320),
        ("     +004500", 4500),
        ("no numbers", 0),
        (" b1234", 0),
        (" 00533 ", 533),
        (" -00533 ", -533),
        ("2147483647", int.MaxValue),
        ("-2147483648", int.MinValue),
        ("100000000000000", int.MaxValue),
        ("-100000000000000", int.MinValue),
        ("   +0 123", 0)
    };
}
