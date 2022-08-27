namespace LeetCodes.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Leet128Bench
{
    private static readonly Leet128 Leet = new Leet128();
    private static readonly (int CaseNo, int[] Nums, int Result) Data = Leet128.Data()[4];

    [Benchmark]
    public int Version1()
        => Leet.LongestConsecutive(Data.Nums);
}
