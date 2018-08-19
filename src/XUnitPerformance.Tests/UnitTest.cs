using System;
using Microsoft.Xunit.Performance;
using Xunit;
using System.Linq;

namespace XUnitPerformance.Tests {
    public class UnitTest {
        [Benchmark]
        public void Test1() {
            foreach (var iteration in Benchmark.Iterations) {
                using (iteration.StartMeasurement()) {
                    _ = "" == null ? true : false;
                }
            }
        }

        [Benchmark]
        public void Test2() {
            foreach (var iteration in Benchmark.Iterations) {
                using (iteration.StartMeasurement()) {
                    _ = "" == "Hello, world!" ? true : false;
                }
            }
        }

        [Benchmark]
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
