using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmark.Benchmarks
{
    public class RandomBenchmarkConfig : ManualConfig
    {
        public RandomBenchmarkConfig()
        {
            Add(Job.RyuJitX64);
            Add(new MemoryDiagnoser());
        }
    }
}