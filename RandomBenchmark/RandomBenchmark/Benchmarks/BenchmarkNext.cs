using BenchmarkDotNet.Attributes;

namespace RandomBenchmark.Benchmarks
{
    [Config(typeof(RandomBenchmarkConfig))]
    public class BenchmarkNext : BaseBenchmark
    {
        [Benchmark(Baseline = true)]
        public override void WithRandom()
        {
            Random.Next();
        }

        [Benchmark]
        public override void WithXorShift()
        {
            XorShift.Next();
        }

        [Benchmark]
        public override void WithXorShiRo()
        {
            XorShiRo.Next();
        }
    }
}