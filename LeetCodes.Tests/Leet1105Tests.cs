namespace LeetCodes.Tests;

using Xunit;

public class Leet1105Tests
{
    private static readonly Leet1105 Leet = new();

    [Theory]
    [MemberData(nameof(GetData))]
    public void MinHeightShelves(string name, int[][] books, int shelfWidth, int expected)
    {
        var actual = Leet.MinHeightShelves(books, shelfWidth);
        Assert.True(expected == actual, $"case: {name}, expected: {expected}, actual: {actual}");
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void MinHeightShelvesRecursive(string name, int[][] books, int shelfWidth, int expected)
    {
        var actual = Leet.MinHeightShelvesRecursive(books, shelfWidth);
        Assert.True(expected == actual, $"case: {name}, expected: {expected}, actual: {actual}");
    }

    public static IEnumerable<object[]> GetData()
    {
        foreach (var (name, books, shelfWidth, minShelfHeight) in Leet1105.Data)
        {
            yield return [name, books, shelfWidth, minShelfHeight];
        }
    }
}
