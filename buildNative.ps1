Push-Location $PSScriptRoot

function GetPackage([string]$name, [string]$version)
{
    $filename = "$PSScriptRoot/packages/$name.$version.nupkg"
    if(!(Test-Path $filename))
    {
        $wc = New-Object System.Net.WebClient
        $wc.DownloadFile("https://www.nuget.org/api/v2/package/$name/$version", $filename)
    }
    Expand-Archive $filename "packages/$name"
}

try
{
    if(!(Test-Path packages)) { New-Item packages -ItemType Directory | Out-Null }
    if(Test-Path runtimes) { Remove-Item runtimes -Force -Recurse }
    New-Item runtimes -ItemType Directory | Out-Null

    GetPackage intelmkl.redist.win-x64 2020.3.279
    New-Item runtimes/win-x64/native -ItemType Directory | Out-Null
    Copy-Item packages/intelmkl.redist.win-x64/runtimes/win-x64/native/*.dll runtimes/win-x64/native
    Remove-Item packages/intelmkl.redist.win-x64 -Force -Recurse

    GetPackage intelmkl.redist.win-x86 2020.3.279
    New-Item runtimes/win-x86/native -ItemType Directory | Out-Null
    Copy-Item packages/intelmkl.redist.win-x86/runtimes/win-x86/native/*.dll runtimes/win-x86/native
    Remove-Item packages/intelmkl.redist.win-x86 -Force -Recurse
    
    GetPackage intelopenmp.redist.win 2020.2.254
    Copy-Item packages/intelopenmp.redist.win/runtimes/win-x64/native/*.dll runtimes/win-x64/native
    Copy-Item packages/intelopenmp.redist.win/runtimes/win-x86/native/*.dll runtimes/win-x86/native
    Remove-Item packages/intelopenmp.redist.win -Force -Recurse
    
    GetPackage inteltbb.redist.win 2020.3.254
    Copy-Item packages/inteltbb.redist.win/runtimes/win-x64/native/*.dll runtimes/win-x64/native
    Copy-Item packages/inteltbb.redist.win/runtimes/win-x86/native/*.dll runtimes/win-x86/native
    Remove-Item packages/inteltbb.redist.win -Force -Recurse

    GetPackage intelmkl.devel.linux-x64 2020.3.279
    New-Item runtimes/linux-x64/native -ItemType Directory | Out-Null
    Copy-Item packages/intelmkl.devel.linux-x64/lib/native/linux-x64/*.so runtimes/linux-x64/native
    Remove-Item packages/intelmkl.devel.linux-x64 -Force -Recurse

    GetPackage intelmkl.devel.linux-x86 2020.3.279
    New-Item runtimes/linux-x86/native -ItemType Directory | Out-Null
    Copy-Item packages/intelmkl.devel.linux-x86/lib/native/linux-x86/*.so runtimes/linux-x86/native
    Remove-Item packages/intelmkl.devel.linux-x86 -Force -Recurse

    GetPackage intelopenmp.devel.linux 2020.2.254
    Copy-Item packages/intelopenmp.devel.linux/lib/native/linux-x64/*.so runtimes/linux-x64/native
    Copy-Item packages/intelopenmp.devel.linux/lib/native/linux-x86/*.so runtimes/linux-x86/native
    Remove-Item packages/intelopenmp.devel.linux -Force -Recurse

    GetPackage inteltbb.devel.linux 2020.3.254
    Copy-Item packages/inteltbb.devel.linux/lib/native/linux-x64/*.so runtimes/linux-x64/native
    Copy-Item packages/inteltbb.devel.linux/lib/native/linux-x86/*.so runtimes/linux-x86/native
    Remove-Item packages/inteltbb.devel.linux -Force -Recurse

    GetPackage intelmkl.devel.osx-x64 2020.3.279
    New-Item runtimes/osx-x64/native -ItemType Directory | Out-Null
    Copy-Item packages/intelmkl.devel.osx-x64/lib/native/osx-x64/*.dylib runtimes/osx-x64/native
    Remove-Item packages/intelmkl.devel.osx-x64 -Force -Recurse

    GetPackage intelopenmp.devel.osx 2020.2.258
    Copy-Item packages/intelopenmp.devel.osx/mac/compiler/lib/*.dylib runtimes/osx-x64/native
    Remove-Item packages/intelopenmp.devel.osx -Force -Recurse

    GetPackage inteltbb.devel.osx 2020.3.258
    Copy-Item packages/inteltbb.devel.osx/runtimes/osx-x64/native/*.dylib runtimes/osx-x64/native
    Remove-Item packages/inteltbb.devel.osx -Force -Recurse

    dotnet pack MKL.NET.win-x64 -o packages -p:Version=2020.3.279
    dotnet pack MKL.NET.win-x86 -o packages -p:Version=2020.3.279
    dotnet pack MKL.NET.linux-x64 -o packages -p:Version=2020.3.279
    dotnet pack MKL.NET.linux-x86 -o packages -p:Version=2020.3.279
    dotnet pack MKL.NET.osx-x64 -o packages -p:Version=2020.3.279
}
finally { Pop-Location }