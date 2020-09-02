# MKL.NET

A simple cross platform .NET API for Intel MKL.

Reference the package and use the static MKL functions. The correct native libraries will be included and loaded at runtime.

Exposing functions from MKL for double data types, keeping the syntax as close to the [c developer reference](https://software.intel.com/content/www/us/en/develop/documentation/mkl-developer-reference-c/top.html) as possible.

Multiple packages to optimise size e.g.

MKL.NET.Win.Linux.nupkg -- Win and Linux, x64 and x86  
MKL.NET.Win.Linux.x64.nupkg -- Win and Linux, x64  
MKL.NET.Win.Linux.x86.nupkg -- Win and Linux, x86  
MKL.NET.Win.Linux.OSX.nupkg -- Win, Linux, and OSX, x64 and x86  
MKL.NET.Win.Linux.OSX.x64.nupkg -- Win, Linux, and OSX, x64  
MKL.NET.Win.Linux.OSX.x86.nupkg -- Win, Linux, and OSX, x86  

Open source rationale:

- Use freely available Intel MKL packages without bringing them in house.
- The API is just a thin .NET wrapper around the native API keeping the syntax as close as possible.
- The project is well defined with no business logic and could benefit from external input.
- Cross platform testing is easy and free using Github actions.
- MKL.NET packages can just be white listed for use in house.
