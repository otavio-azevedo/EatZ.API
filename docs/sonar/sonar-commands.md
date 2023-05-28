dotnet sonarscanner begin /k:"eatz.api" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="sqp_950bd59a0fd8bc78560a5c784ba107161e639955" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
dotnet build --no-incremental
dotnet-coverage collect 'dotnet test' -f xml  -o 'coverage.xml'
dotnet sonarscanner end /d:sonar.login="sqp_950bd59a0fd8bc78560a5c784ba107161e639955"