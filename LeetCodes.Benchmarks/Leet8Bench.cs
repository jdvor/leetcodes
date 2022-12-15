namespace LeetCodes.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Leet8Bench
{
    private static readonly Leet8 Leet = new Leet8();

    [Benchmark]
    public int Version1()
        => Leet.MyAtoi("     +004500");
}
