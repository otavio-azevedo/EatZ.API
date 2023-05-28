# SonarQube

This directory contains the docker-compose file for static analisys purpose in local environment. If you are using WSL, probably will be necessary run the command below to run correctly your containers.

- sysctl -w vm.max_map_count=262144

## Commands

### 1. Starts the analisys

dotnet sonarscanner begin /k:"eatz.api" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="sqp_950bd59a0fd8bc78560a5c784ba107161e639955" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml

- Its necessary configure your local environment on SonarQube platform first to get the key and login infos.

### 2. Build application

dotnet build --no-incremental

### 3. Run and collect unit tests

dotnet-coverage collect 'dotnet test' -f xml -o 'coverage.xml'

### 4. Ends Run

dotnet sonarscanner end /d:sonar.login="sqp_950bd59a0fd8bc78560a5c784ba107161e639955"
