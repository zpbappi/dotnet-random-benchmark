using BenchmarkDotNet.Running;
using RandomBenchmark.Benchmarks;

namespace RandomBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(BenchmarkNext),
                typeof(BenchmarkNextDouble),
                typeof(BenchmarkNextBytes)
            });

            switcher.Run(args);
        }
    }
}
