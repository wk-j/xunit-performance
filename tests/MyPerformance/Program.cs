using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System.Linq;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Horology;
using System.Threading;

public class MyBenchmarks {
    public class Config : ManualConfig {
        public Config() {
            Add(
                Job.Dry
                .With(Platform.X64)
                .With(Jit.RyuJit)
                .With(Runtime.Core)
                .WithLaunchCount(1)
                // .WithIterationTime(TimeInterval.Millisecond * 200)
                //.WithMaxStdErrRelative(0.01)
                .WithId("MySuperJob"));
        }
    }
}

[Config(typeof(MyBenchmarks.Config))]
public class Test {
    [Benchmark]
    public void A() { }

    [Benchmark]
    public void B() { }

    [Benchmark]
    public void C() {
        Thread.Sleep(1000);
        String.Format("{0}{1}{2}", "A", "B", "C");
    }
}

namespace MyPerformance {
    class Program {
        static void Main(string[] args) {
            BenchmarkRunner.Run<Test>();
        }
    }
}
