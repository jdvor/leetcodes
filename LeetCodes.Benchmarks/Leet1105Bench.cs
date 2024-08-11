namespace LeetCodes.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Leet1105Bench
{
    private static readonly Leet1105 Leet = new();
    private static readonly int[][] Books = Leet1105.Data[0].books;
    private static readonly int ShelfWidth = Leet1105.Data[0].shelfWidth;

    [Benchmark]
    public int Version1()
        => Leet.MinHeightShelves(Books, ShelfWidth);
}
