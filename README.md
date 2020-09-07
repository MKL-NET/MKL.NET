# MKL.NET

<p>
<a href="https://github.com/AnthonyLloyd/MKL.NET/actions"><img src="https://github.com/AnthonyLloyd/MKL.NET/workflows/ci/badge.svg?branch=master"></a>
</p>

A simple cross platform .NET API for Intel MKL.

Exposing functions from MKL keeping the syntax as close to the
[c developer reference](https://software.intel.com/content/www/us/en/develop/documentation/mkl-developer-reference-c/top.html) as possible.

Reference the MKL.NET package and required runtime packages and use the static MKL functions.
The correct native libraries will be included and loaded at runtime.

<p>MKL.NET: <a href="https://www.nuget.org/packages/MKL.NET"><img src="https://buildstats.info/nuget/MKL.NET?includePreReleases=true" /></p>
<p>MKL.NET.win-x64: <a href="https://www.nuget.org/packages/MKL.NET.win-x64"><img src="https://buildstats.info/nuget/MKL.NET.win-x64?includePreReleases=true" /></p>
<p>MKL.NET.win-x86: <a href="https://www.nuget.org/packages/MKL.NET.win-x86"><img src="https://buildstats.info/nuget/MKL.NET.win-x86?includePreReleases=true" /></p>
<p>MKL.NET.linux-x64: <a href="https://www.nuget.org/packages/MKL.NET.linux-x64"><img src="https://buildstats.info/nuget/MKL.NET.linux-x64?includePreReleases=true" /></p>
<p>MKL.NET.linux-x86: <a href="https://www.nuget.org/packages/MKL.NET.linux-x86"><img src="https://buildstats.info/nuget/MKL.NET.linux-x86?includePreReleases=true" /></p>
<p>MKL.NET.osx-x64: <a href="https://www.nuget.org/packages/MKL.NET.osx-x64"><img src="https://buildstats.info/nuget/MKL.NET.osx-x64?includePreReleases=true" /></p>

Open source rationale:

- Use freely available Intel MKL packages without bringing them in house.
- The API is just a thin .NET wrapper around the native API keeping the syntax as close as possible.
- The project is well defined with no business logic and could benefit from external input.
- Cross platform testing is easy and free using Github actions.
- MKL.NET packages can just be white listed for use in house.