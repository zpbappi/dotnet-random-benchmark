using System;
using BenchmarkDotNet.Attributes;

namespace RandomBenchmark.Benchmarks
{
    [Config(typeof(RandomBenchmarkConfig))]
    public class BenchmarkNextDouble : BaseBenchmark
    {
        [Benchmark(Baseline = true)]
        public override void WithRandom()
        {
            Random.NextDouble();
        }

        [Benchmark]
        public override void WithXorShift()
        {
            XorShift.NextDouble();
        }

        [Benchmark]
        public override void WithXorShiRo()
        {
            XorShiRo.NextDouble();
        }
    }
}