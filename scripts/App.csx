#! "netcoreapp2.1"
#r "nuget:BenchmarkDotNet,0.10.12"

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

public class FastAndDirtyConfig : ManualConfig {
    public FastAndDirtyConfig() {
        Add(DefaultConfig.Instance); // *** add default loggers, reporters etc? ***

        Add(Job.Default
            .WithLaunchCount(1)     // benchmark process will be launched only once
            .WithWarmupCount(1)     // 3 warmup iteration
            .WithTargetCount(1)     // 3 target iteration
        );
    }
}

[InProcess]
// [Config(typeof(FastAndDirtyConfig))]
[SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1)]
public class Test {

    int[] values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

    [Benchmark]
    public void Take() {
        var a = values.Skip(5).Count();
    }

    [Benchmark]
    public void A() {

    }

    [Benchmark]
    public void B() {

    }

}

BenchmarkRunner.Run<Test>();
