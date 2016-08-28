using System;

namespace RandomBenchmark.Benchmarks
{
    public abstract class BaseBenchmark
    {
        protected BaseBenchmark()
        {
            var seed = Environment.TickCount;

            Random = new Random(seed);
            XorShift = new XorShiftRandom(seed);
            XorShiRo = new XorShiRoRandom(seed);
        }

        protected Random Random { get; private set; }

        protected XorShiftRandom XorShift { get; private set; }

        protected XorShiRoRandom XorShiRo { get; private set; }

        public abstract void WithRandom();

        public abstract void WithXorShift();

        public abstract void WithXorShiRo();
    }
}
