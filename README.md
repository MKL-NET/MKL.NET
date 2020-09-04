# MKL.NET

A simple cross platform .NET API for Intel MKL.

Exposing functions from MKL keeping the syntax as close to the
[c developer reference](https://software.intel.com/content/www/us/en/develop/documentation/mkl-developer-reference-c/top.html) as possible.

Reference the MKL.NET package and required runtime packages and use the static MKL functions.
The correct native libraries will be included and loaded at runtime.

MKL.NET.nupkg  
MKL.NET.win-x64.nupkg  
MKL.NET.win-x86.nupkg  
MKL.NET.linux-x64.nupkg  
MKL.NET.linux-x86.nupkg  
MKL.NET.osx-x64.nupkg  

Open source rationale:

- Use freely available Intel MKL packages without bringing them in house.
- The API is just a thin .NET wrapper around the native API keeping the syntax as close as possible.
- The project is well defined with no business logic and could benefit from external input.
- Cross platform testing is easy and free using Github actions.
- MKL.NET packages can just be white listed for use in house.