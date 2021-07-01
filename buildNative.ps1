Push-Location $PSScriptRoot

function GetPackage([string]$name, [string]$version)
{
    $filename = "$PSScriptRoot/packages/$name.$version.nupkg"
    if(!(Test-Path $filename))
    {
        $wc = New-Object System.Net.WebClient
        $wc.DownloadFile("https://www.nuget.org/api/v2/package/$name/$version", $filename)
    }
    $temp_zip_filename = "$PSScriptRoot/packages/$name.$version.zip"
    Copy-Item $filename $temp_zip_filename
    Expand-Archive $temp_zip_filename "packages/$name"
    Remove-Item $temp_zip_filename
}

function DownloadFile([string]$source, [string]$localFilename)
{
    if(!(Test-Path $localFilename))
    {
        $wc = New-Object System.Net.WebClient
        $wc.DownloadFile($source, $localFilename)
    }
}

try
{
    if(!(Test-Path packages)) { New-Item packages -ItemType Directory | Out-Null }
    if(Test-Path runtimes) { Remove-Item runtimes -Force -Recurse }
    New-Item runtimes -ItemType Directory | Out-Null

    GetPackage intelmkl.redist.win-x64 2021.3.0.524
    New-Item runtimes/win-x64/native -ItemType Directory | Out-Null
    Copy-Item packages/intelmkl.redist.win-x64/runtimes/win-x64/native/*.dll runtimes/win-x64/native
    Remove-Item packages/intelmkl.redist.win-x64 -Force -Recurse
    Move-Item runtimes/win-x64/native/mkl_rt.1.dll runtimes/win-x64/native/mkl_rt.dll

    GetPackage intelmkl.redist.win-x86 2021.3.0.524
    New-Item runtimes/win-x86/native -ItemType Directory | Out-Null
    Copy-Item packages/intelmkl.redist.win-x86/runtimes/win-x86/native/*.dll runtimes/win-x86/native
    Remove-Item packages/intelmkl.redist.win-x86 -Force -Recurse
    Move-Item runtimes/win-x86/native/mkl_rt.1.dll runtimes/win-x86/native/mkl_rt.dll
    
    GetPackage intelopenmp.redist.win 2021.3.0.3372
    Copy-Item packages/intelopenmp.redist.win/runtimes/win-x64/native/*.dll runtimes/win-x64/native
    Copy-Item packages/intelopenmp.redist.win/runtimes/win-x86/native/*.dll runtimes/win-x86/native
    Remove-Item packages/intelopenmp.redist.win -Force -Recurse
    
    GetPackage inteltbb.redist.win 2021.3.0.511
    Copy-Item packages/inteltbb.redist.win/runtimes/win-x64/native/*.dll runtimes/win-x64/native
    Copy-Item packages/inteltbb.redist.win/runtimes/win-x86/native/*.dll runtimes/win-x86/native
    Remove-Item packages/inteltbb.redist.win -Force -Recurse

    # https://software.intel.com/content/www/us/en/develop/tools/oneapi/components/onemkl/download.html
    DownloadFile https://registrationcenter-download.intel.com/akdlm/irc_nas/17901/l_onemkl_p_2021.3.0.520_offline.sh "packages/l_onemkl_p_2021.3.0.520_offline.sh"
    7z x -opackages .\packages\l_onemkl_p_2021.3.0.520_offline.sh ujvgm.tar
    7z x -opackages\ujvgm .\packages\ujvgm.tar
    Remove-Item packages/ujvgm.tar
    7z x -opackages\ujvgm\cupPayload ".\packages\ujvgm\packages\intel.oneapi.lin.mkl.runtime,v=2021.3.0-520\cupPayload.cup"
    Remove-Item packages/ujvgm/cupPayload/_installdir/mkl/2021.3.0/lib/intel64/libmkl_sycl.so.1
    New-Item runtimes/linux-x64/native -ItemType Directory | Out-Null
    Copy-Item packages/ujvgm/cupPayload/_installdir/mkl/2021.3.0/lib/intel64/*.1 runtimes/linux-x64/native
    New-Item runtimes/linux-x86/native -ItemType Directory | Out-Null
    Copy-Item packages/ujvgm/cupPayload/_installdir/mkl/2021.3.0/lib/ia32/*.1 runtimes/linux-x86/native
    Remove-Item packages/ujvgm -Force -Recurse
    Move-Item runtimes/linux-x64/native/libmkl_rt.so.1 runtimes/linux-x64/native/libmkl_rt.so
    Move-Item runtimes/linux-x86/native/libmkl_rt.so.1 runtimes/linux-x86/native/libmkl_rt.so
    New-Item runtimes/linux-x64.b/native -ItemType Directory | Out-Null
    Move-Item runtimes/linux-x64/native/libmkl_core.so.1 runtimes/linux-x64.b/native/libmkl_core.so.1
    Move-Item runtimes/linux-x64/native/libmkl_avx512_mic.so.1 runtimes/linux-x64.b/native/libmkl_avx512_mic.so.1
    Move-Item runtimes/linux-x64/native/libmkl_intel_thread.so.1 runtimes/linux-x64.b/native/libmkl_intel_thread.so.1
    Move-Item runtimes/linux-x64/native/libmkl_avx512.so.1 runtimes/linux-x64.b/native/libmkl_avx512.so.1
    Move-Item runtimes/linux-x64/native/libmkl_avx.so.1 runtimes/linux-x64.b/native/libmkl_avx.so.1
    Move-Item runtimes/linux-x64/native/libmkl_mc3.so.1 runtimes/linux-x64.b/native/libmkl_mc3.so.1

    # GetPackage intelmkl.devel.linux-x64 2020.4.304
    # New-Item runtimes/linux-x64/native -ItemType Directory | Out-Null
    # Copy-Item packages/intelmkl.devel.linux-x64/lib/native/linux-x64/*.so runtimes/linux-x64/native
    # Remove-Item packages/intelmkl.devel.linux-x64 -Force -Recurse
    # 
    # GetPackage intelmkl.devel.linux-x86 2021.2.0.296
    # New-Item runtimes/linux-x86/native -ItemType Directory | Out-Null
    # Copy-Item packages/intelmkl.devel.linux-x86/lib/native/linux-x86/*.so runtimes/linux-x86/native
    # Remove-Item packages/intelmkl.devel.linux-x86 -Force -Recurse

    GetPackage intelopenmp.devel.linux 2021.3.0.3350
    Copy-Item packages/intelopenmp.devel.linux/lib/native/linux-x64/*.so runtimes/linux-x64/native
    Copy-Item packages/intelopenmp.devel.linux/lib/native/linux-x86/*.so runtimes/linux-x86/native
    Remove-Item packages/intelopenmp.devel.linux -Force -Recurse

    GetPackage inteltbb.devel.linux 2021.3.0.511
    Copy-Item packages/inteltbb.devel.linux/runtimes/linux-x64/native/*.so runtimes/linux-x64/native
    Copy-Item packages/inteltbb.devel.linux/runtimes/linux-x86/native/*.so runtimes/linux-x86/native
    Remove-Item packages/inteltbb.devel.linux -Force -Recurse

    GetPackage intelmkl.devel.osx-x64 2021.2.0.269
    New-Item runtimes/osx-x64/native -ItemType Directory | Out-Null
    Copy-Item packages/intelmkl.devel.osx-x64/lib/native/osx-x64/*.dylib runtimes/osx-x64/native
    Remove-Item packages/intelmkl.devel.osx-x64 -Force -Recurse
    Remove-Item runtimes/osx-x64/native/libmkl_rt.dylib
    Remove-Item runtimes/osx-x64/native/libmkl_core.dylib
    Remove-Item runtimes/osx-x64/native/libmkl_intel_ilp64.dylib
    Remove-Item runtimes/osx-x64/native/libmkl_intel_lp64.dylib
    Remove-Item runtimes/osx-x64/native/libmkl_intel_thread.dylib
    Remove-Item runtimes/osx-x64/native/libmkl_sequential.dylib
    Remove-Item runtimes/osx-x64/native/libmkl_tbb_thread.dylib
    Move-Item runtimes/osx-x64/native/libmkl_rt.1.dylib runtimes/osx-x64/native/libmkl_rt.dylib

    GetPackage intelopenmp.devel.osx 2021.3.0.3375
    Copy-Item packages/intelopenmp.devel.osx/lib/native/osx-x64/*.dylib runtimes/osx-x64/native
    Remove-Item packages/intelopenmp.devel.osx -Force -Recurse

    GetPackage inteltbb.devel.osx 2021.3.0.511
    Copy-Item packages/inteltbb.devel.osx/runtimes/osx-x64/native/*.dylib runtimes/osx-x64/native
    Remove-Item packages/inteltbb.devel.osx -Force -Recurse

    dotnet pack MKL.NET.win-x64 -o packages -p:Version=2021.3.0.524
    dotnet pack MKL.NET.win-x86 -o packages -p:Version=2021.3.0.524
    dotnet pack MKL.NET.linux-x64 -o packages -p:Version=2021.3.0.520
    dotnet pack MKL.NET.linux-x64.b -o packages -p:Version=2021.3.0.520
    dotnet pack MKL.NET.linux-x86 -o packages -p:Version=2021.3.0.520
    dotnet pack MKL.NET.osx-x64 -o packages -p:Version=2021.2.0.269
}
finally { Pop-Location }

# dotnet nuget push .\packages\MKL.NET.win-x64.2021.3.0.524.nupkg -k $env:NUGET_KEY -s https://api.nuget.org/v3/index.json