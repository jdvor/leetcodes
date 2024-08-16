namespace LeetCodes.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Leet121Bench
{
    private static readonly Leet121 Leet = new();
    private static readonly int[] Nums = [7, 1, 5, 3, 6, 4];

    [Benchmark]
    public int Version1()
        => Leet.MaxProfit(Nums);
}
