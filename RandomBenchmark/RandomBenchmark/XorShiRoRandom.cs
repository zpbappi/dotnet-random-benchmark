using System;

namespace RandomBenchmark
{
    public class XorShiRoRandom
    {
        private readonly ulong[] _state;
        private const double NormalizationFactor = 1.0 / int.MaxValue;

        private ulong _seed;
        private bool _takeMsb = true;
        private ulong _currentPartialResult;

        public XorShiRoRandom(int seed)
        {
            _seed = (ulong)seed;
            _state = new[] { SplitMix64(), SplitMix64() };
        }

        public virtual int Next()
        {
            var sample = InternalSample() & int.MaxValue;

            return sample == int.MaxValue
                ? --sample
                : sample;
        }

        public virtual int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException(nameof(minValue));

            var range = (long)maxValue - minValue;

            return minValue + (int)(range * NextDouble());
        }

        public virtual int Next(int maxValue)
        {
            if (maxValue < 0)
                throw new ArgumentOutOfRangeException(nameof(maxValue));

            return (int)(NextDouble() * maxValue);
        }

        public virtual double NextDouble()
        {
            var sample = Next();

            return sample * NormalizationFactor;
        }

        public virtual void NextBytes(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            var tmp = BitConverter.GetBytes(InternalSample());
            short index = 0;
            for (var i = 0; i < buffer.Length; ++i)
            {
                if (index == 4)
                {
                    index = 0;
                    tmp = BitConverter.GetBytes(InternalSample());
                }

                buffer[i] = tmp[index++];
            }
        }

        private int InternalSample()
        {
            int sample;

            if (_takeMsb)
            {
                _currentPartialResult = XorShiRo128Plus();
                sample = unchecked((int)(_currentPartialResult >> 32));
            }
            else
            {
                sample = unchecked((int)_currentPartialResult);
            }

            _takeMsb = !_takeMsb;

            return sample;
        }

        private ulong SplitMix64()
        {
            var z = unchecked(_seed += 0x9E3779B97F4A7C15);
            z = unchecked((z ^ (z >> 30)) * 0xBF58476D1CE4E5B9);
            z = unchecked((z ^ (z >> 27)) * 0x94D049BB133111EB);
            return z ^ (z >> 31);
        }

        private static ulong RotateLeft(ulong x, int k)
        {
            return (x << k) | (x >> (64 - k));
        }

        private ulong XorShiRo128Plus()
        {
            var s0 = _state[0];
            var s1 = _state[1];
            var result = s0 + s1;

            s1 ^= s0;
            _state[0] = RotateLeft(s0, 55) ^ s1 ^ (s1 << 14);
            _state[1] = RotateLeft(s1, 36);

            return result;
        }
    }
}