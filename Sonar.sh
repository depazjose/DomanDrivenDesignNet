#!/bin/bash
token="admin"
dir="$(pwd)"

dotnet sonarscanner begin /d:sonar.login="admin" /d:sonar.password="admin" /k:"MDTNetCore" /d:sonar.language="cs" /d:sonar.exclusions="**/bin/**/*,**/obj/**/*" /d:sonar.cs.opencover.reportsPaths="${dir}/lcov.opencover.xml"  /d:sonar.coverage.exclusions="test/**"
dotnet restore
dotnet build
dotnet test test/Infrastructure/EntryPoint/MDT.Web.Test/MDT.Web.Test.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=\"opencover,lcov\" /p:CoverletOutput=../lcov
dotnet sonarscanner end /d:sonar.login="admin" /d:sonar.password="admin"

