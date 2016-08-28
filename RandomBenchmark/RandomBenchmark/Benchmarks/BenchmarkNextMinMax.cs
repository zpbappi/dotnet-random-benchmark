using BenchmarkDotNet.Attributes;

namespace RandomBenchmark.Benchmarks
{
    [Config(typeof(RandomBenchmarkConfig))]
    public class BenchmarkNextMinMax : BaseBenchmark
    {
        [Benchmark(Baseline = true)]
        public override void WithRandom()
        {
            Random.Next(int.MinValue, int.MaxValue);
        }

        [Benchmark]
        public override void WithXorShift()
        {
            XorShift.Next(int.MinValue, int.MaxValue);
        }

        [Benchmark]
        public override void WithXorShiRo()
        {
            XorShiRo.Next(int.MinValue, int.MaxValue);
        }
    }
}