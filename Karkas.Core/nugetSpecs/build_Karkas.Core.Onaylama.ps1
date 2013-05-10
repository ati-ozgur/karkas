$projectName = "Karkas.Core.Onaylama"
$version = Get-Content version.txt
remove-item $projectName/lib -recurse
mkdir $projectName/lib
#mkdir tools
#mkdir content
msbuild   "..\Karkas.Core.2010.sln"
copy ../$projectName/bin/Debug/$projectName.dll $projectName/lib
../packages/NuGet.CommandLine.2.5.0/tools/NuGet pack  $projectName/$projectName.nuspec -Version $version

