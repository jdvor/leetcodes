namespace LeetCodes.Tests;

using System.Text;
using Xunit;

public class Leet1105Tests
{
    private static readonly Leet1105 Leet = new();

    [Theory]
    [MemberData(nameof(GetData))]
    public void Test(int[][] books, int shelfWidth, int expected)
    {
        var actual = Leet.MinHeightShelves(books, shelfWidth);
        Assert.True(expected == actual, $"books: '{ToStr(books)}', expected: {expected}, actual: {actual}");
    }

    public static IEnumerable<object[]> GetData()
    {
        foreach (var (books, shelfWidth, minShelfHeight) in Leet1105.Data)
        {
            yield return [books, shelfWidth, minShelfHeight];
        }
    }

    private static string ToStr(int[][] books)
    {
        var sb = new StringBuilder(2 + books.Length * 7);
        var first = true;
        foreach (var b in books)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                sb.Append(", ");
            }

            sb.Append($"[{b[0]},{b[1]}]");
        }

        return sb.ToString();
    }
}
