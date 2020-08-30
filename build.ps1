Push-Location $PSScriptRoot

function CopyPackageItem([string]$name, [string]$version, [string]$source, [string]$destination)
{
    $filename = "$PSScriptRoot/packages/$name.$version.zip"
    if(!(Test-Path $filename))
    {
        $wc = New-Object System.Net.WebClient
        $wc.DownloadFile("https://www.nuget.org/api/v2/package/$name/$version", $filename)
    }
    Expand-Archive $filename "packages/$name"
    Copy-Item "packages/$name/$source" "MKL.NET/$destination" -Recurse -Force
    Remove-Item "packages/$name" -Force -Recurse
}

try
{
    if(!(Test-Path packages)) { New-Item packages -ItemType Directory | Out-Null }
    if(Test-Path MKL.NET/runtimes) { Remove-Item MKL.NET/runtimes -Force -Recurse }
    New-Item MKL.NET/runtimes -ItemType Directory | Out-Null
    CopyPackageItem "intelmkl.redist.win-x64" "2020.2.254" runtimes
    CopyPackageItem "intelmkl.redist.win-x86" "2020.2.254" runtimes
    CopyPackageItem "intelopenmp.redist.win" "2020.2.254" runtimes
    CopyPackageItem "inteltbb.redist.win" "2020.3.254" runtimes
    CopyPackageItem "intelmkl.devel.linux-x64" "2020.2.254" lib/native/linux-x64/* runtimes/linux-x64/native
    CopyPackageItem "intelopenmp.devel.linux" "2020.2.254" lib/native/linux-x64/* runtimes/linux-x64/native
    CopyPackageItem "inteltbb.devel.linux" "2020.3.254" lib/native/linux-x64/* runtimes/linux-x64/native
    CopyPackageItem "intelmkl.devel.osx-x64" "2020.2.258" lib/native/osx-x64/* runtimes/osx-x64/native
    CopyPackageItem "intelopenmp.devel.osx" "2020.2.258" mac/compiler/lib/* runtimes/osx-x64/native
    CopyPackageItem "inteltbb.devel.osx" "2020.3.258" runtimes

    dotnet pack MKL.NET -c Release -o packages
}
finally { Pop-Location }