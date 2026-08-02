@echo off
echo ====================================================================
echo  XrmToolBox Global Tool Library NuGet Publishing Script
echo ====================================================================
echo.
echo Building Visual Studio 2022 Solution in Release mode...
dotnet build DataverseBulkImageUploader.csproj -c Release

echo.
echo Packing NuGet Package with XrmToolBoxPackage tag...
nuget pack DataverseBulkImageUploader.nuspec -OutputDirectory ./bin/nupkg

echo.
echo ====================================================================
echo  Ready to publish to NuGet.org!
echo ====================================================================
echo Enter your NuGet.org API Key to push package globally:
set /p NUGET_API_KEY="NuGet API Key: "

echo Pushing package to NuGet.org...
nuget push ./bin/nupkg/DataverseBulkImageUploader.XrmToolBox.1.2.8.nupkg -ApiKey %NUGET_API_KEY% -Source https://api.nuget.org/v3/index.json

echo.
echo SUCCESS! Your plugin will automatically appear in the XrmToolBox Tool Library worldwide within 15 minutes!
pause