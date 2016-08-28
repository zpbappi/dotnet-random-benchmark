# dotnet-random-benchmark
Benchmark of `Next()`, `NextDouble()` and `NextBytes(byte[])` for XorShift128+, XorShiRo128+ and .NET built-in Random class

## Benchmark for `Next()`

```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4710HQ CPU 2.50GHz, ProcessorCount=8
Frequency=2439991 ticks, Resolution=409.8376 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1080.0

Type=BenchmarkNext  Mode=Throughput  Platform=X64  
Jit=RyuJit  

```
       Method |    Median |    StdDev | Scaled | Scaled-SD | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------- |---------- |---------- |------- |---------- |------ |------ |------ |------------------- |
   WithRandom | 8.5704 ns | 0.2965 ns |   1.00 |      0.00 |     - |     - |     - |               0.00 |
 WithXorShift | 5.1833 ns | 0.2376 ns |   0.60 |      0.03 |     - |     - |     - |               0.00 |
 WithXorShiRo | 6.1830 ns | 0.1020 ns |   0.72 |      0.03 |     - |     - |     - |               0.00 |


## Benchmark for `Next(int, int)`

```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4710HQ CPU 2.50GHz, ProcessorCount=8
Frequency=2439991 ticks, Resolution=409.8376 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1080.0

Type=BenchmarkNextMinMax  Mode=Throughput  Platform=X64  
Jit=RyuJit  

```
       Method |     Median |    StdDev | Scaled | Scaled-SD | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------- |----------- |---------- |------- |---------- |------ |------ |------ |------------------- |
   WithRandom | 24.0499 ns | 0.1312 ns |   1.00 |      0.00 |     - |     - |     - |               0.00 |
 WithXorShift |  7.9741 ns | 0.1516 ns |   0.33 |      0.01 |     - |     - |     - |               0.00 |
 WithXorShiRo | 10.0711 ns | 0.2151 ns |   0.42 |      0.01 |     - |     - |     - |               0.00 |


## Benchmark for `NextDouble()`

```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4710HQ CPU 2.50GHz, ProcessorCount=8
Frequency=2439991 ticks, Resolution=409.8376 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1080.0

Type=BenchmarkNextDouble  Mode=Throughput  Platform=X64  
Jit=RyuJit  

```
       Method |    Median |    StdDev | Scaled | Scaled-SD | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------- |---------- |---------- |------- |---------- |------ |------ |------ |------------------- |
   WithRandom | 9.7515 ns | 0.4409 ns |   1.00 |      0.00 |     - |     - |     - |               0.00 |
 WithXorShift | 6.2083 ns | 0.1120 ns |   0.63 |      0.03 |     - |     - |     - |               0.00 |
 WithXorShiRo | 8.0951 ns | 0.1520 ns |   0.82 |      0.04 |     - |     - |     - |               0.00 |


## Benchmark for `NextBytes(byte[])`

```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4710HQ CPU 2.50GHz, ProcessorCount=8
Frequency=2439991 ticks, Resolution=409.8376 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1080.0

Type=BenchmarkNextBytes  Mode=Throughput  Platform=X64  
Jit=RyuJit  

```
       Method |    Median |    StdDev | Scaled | Scaled-SD |    Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------- |---------- |---------- |------- |---------- |--------- |------ |------ |------------------- |
   WithRandom | 8.7393 us | 0.1351 us |   1.00 |      0.00 |   288.00 |     - |     - |             531.85 |
 WithXorShift | 3.9998 us | 0.0163 us |   0.46 |      0.01 | 2,476.36 |     - |     - |           3,954.46 |
 WithXorShiRo | 4.6337 us | 0.2617 us |   0.54 |      0.03 | 2,735.87 |     - |     - |           4,367.64 |
