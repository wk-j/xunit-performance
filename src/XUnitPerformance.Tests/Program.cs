using System.Reflection;
using Microsoft.Xunit.Performance.Api;

static class Program {
    static void Main(string[] args) {
        using (var p = new XunitPerformanceHarness(args)) {
            string entryAssemblyPath = Assembly.GetEntryAssembly().Location;
            p.RunBenchmarks(entryAssemblyPath);
        }
    }
}