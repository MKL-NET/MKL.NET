$dir = "$PSScriptRoot/../packages/devel/"

function GetPackage([string]$name, [string]$version)
{
    $nupkg = $dir + "$name.$version.nupkg"
    $wc = New-Object System.Net.WebClient
    try { $wc.DownloadFile("https://www.nuget.org/api/v2/package/$name/$version", $nupkg) }
    catch { Write-Host ($_.Exception.ToString()) }
    Expand-Archive $nupkg ($dir + $name)
}

if(Test-Path $dir) { Remove-Item $dir -Force -Recurse }
if(!(Test-Path $dir)) { New-Item $dir -ItemType Directory | Out-Null }

if($args.count -eq 0 -or $args[0] -eq 'win-x64') { GetPackage intelmkl.devel.win-x64 2020.4.311 }
if($args.count -eq 0 -or $args[0] -eq 'linux-x64') { GetPackage intelmkl.devel.linux-x64 2020.4.304 }
if($args.count -eq 0 -or $args[0] -eq 'osx-x64') { GetPackage intelmkl.devel.osx-x64 2020.4.301 }