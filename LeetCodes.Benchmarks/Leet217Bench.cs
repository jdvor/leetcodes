namespace LeetCodes.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Leet217Bench
{
    private static readonly Leet217 Leet = new Leet217();
    private static readonly (int CaseNo, int[] Nums, bool Result) Data = Leet217.Data()[2];

    [Benchmark]
    public bool Version1()
        => Leet.ContainsDuplicate(Data.Nums);

    [Benchmark]
    public bool Version2()
        => Leet.ContainsDuplicate2(Data.Nums);
}
