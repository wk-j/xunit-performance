## Command

```bash
dotnet add src/XUnitPerformance.Tests/XUnitPerformance.Tests.csproj  package xunit.performance.api --version 1.0.0-beta-build0020 --source https://dotnet.myget.org/F/dotnet-core/api/v3/index.json


dotnet run --project src/XUnitPerformance.Tests/XUnitPerformance.Tests.csproj --perf:outputdir output
```