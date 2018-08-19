using System;
using Microsoft.Xunit.Performance;
using Xunit;
using System.Linq;

namespace XUnitPerformance.Tests {
    public class UnitTest {
        [Benchmark(InnerIterationCount = 20)]
        [MeasureGCCounts]
        public void Test1() {
            foreach (var iteration in Benchmark.Iterations) {
                using (iteration.StartMeasurement()) {
                    _ = "" == null ? true : false;
                }
            }
        }

        [Benchmark(InnerIterationCount = 20)]
        [MeasureGCCounts]
        public void Test2() {
            foreach (var iteration in Benchmark.Iterations) {
                using (iteration.StartMeasurement()) {
                    _ = "" == "Hello, world!" ? true : false;
                }
            }
        }

        [Benchmark(InnerIterationCount = 10000)]
        public void TestBenchmark() {
            foreach (BenchmarkIteration iter in Benchmark.Iterations) {
                using (iter.StartMeasurement()) {
                    for (int i = 0; i < Benchmark.InnerIterationCount; i++) {
                        string.Format("{0}{1}{2}{3}", "a", "b", "c", "d");
                    }
                }
            }
        }
    }
}
