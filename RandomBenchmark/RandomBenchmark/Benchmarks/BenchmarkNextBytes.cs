using BenchmarkDotNet.Attributes;

namespace RandomBenchmark.Benchmarks
{
    [Config(typeof(RandomBenchmarkConfig))]
    public class BenchmarkNextBytes : BaseBenchmark
    {
        [Benchmark(Baseline = true)]
        public override void WithRandom()
        {
            var arr = new byte[1024];
            Random.NextBytes(arr);
        }

        [Benchmark]
        public override void WithXorShift()
        {
            var arr = new byte[1024];
            XorShift.NextBytes(arr);
        }

        [Benchmark]
        public override void WithXorShiRo()
        {
            var arr = new byte[1024];
            XorShiRo.NextBytes(arr);
        }
    }
}