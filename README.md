# MKL.NET

A simple cross platform API to Intel MKL.

Just reference the package and use the static MKL functions. The correct native libraries will be included and loaded at runtime.

Exposing functions from mkl for double data types keeping the syntax as close to the developer reference as possible:

https://software.intel.com/content/www/us/en/develop/documentation/mkl-developer-reference-c/top.html

Multiple packages to optimise size e.g.

MKL.NET.Win.Linux.nupkg -- Win and Linux, x64 and x86  
MKL.NET.Win.Linux.x64.nupkg -- Win and Linux, x64  
MKL.NET.Win.Linux.x86.nupkg -- Win and Linux, x86  
MKL.NET.Win.Linux.OSX.nupkg -- Win, Linux, and OSX, x64 and x86  
MKL.NET.Win.Linux.OSX.x64.nupkg -- Win, Linux, and OSX, x64  
MKL.NET.Win.Linux.OSX.x86.nupkg -- Win, Linux, and OSX, x86  
