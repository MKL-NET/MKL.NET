# MKL.NET

<p>
<a href="https://github.com/AnthonyLloyd/MKL.NET/actions"><img src="https://github.com/AnthonyLloyd/MKL.NET/workflows/CI/badge.svg?branch=master"></a>
</p>

A simple cross platform .NET API for Intel MKL.

Exposing functions from MKL keeping the syntax as close to the
[c developer reference](https://software.intel.com/content/www/us/en/develop/documentation/mkl-developer-reference-c/top.html) as possible.

Reference the MKL.NET package and required runtime packages and use the static MKL functions.
The correct native libraries will be included and loaded at runtime.

<table>
<tr><td>MKL.NET</td><td><a href="https://www.nuget.org/packages/MKL.NET"><img src="https://buildstats.info/nuget/MKL.NET?includePreReleases=true" ></a></td></tr>
<tr><td>runtimes:</td></tr>
<tr><td>MKL.NET.win-x64</td><td><a href="https://www.nuget.org/packages/MKL.NET.win-x64"><img src="https://buildstats.info/nuget/MKL.NET.win-x64?includePreReleases=true" ></a></td></tr>
<tr><td>MKL.NET.win-x86</td><td><a href="https://www.nuget.org/packages/MKL.NET.win-x86"><img src="https://buildstats.info/nuget/MKL.NET.win-x86?includePreReleases=true" ></a></td></tr>
<tr><td>MKL.NET.linux-x64</td><td><a href="https://www.nuget.org/packages/MKL.NET.linux-x64"><img src="https://buildstats.info/nuget/MKL.NET.linux-x64?includePreReleases=true" ></a></td></tr>
<tr><td>MKL.NET.linux-x86</td><td><a href="https://www.nuget.org/packages/MKL.NET.linux-x86"><img src="https://buildstats.info/nuget/MKL.NET.linux-x86?includePreReleases=true" ></a></td></tr>
<tr><td>MKL.NET.osx-x64</td><td><a href="https://www.nuget.org/packages/MKL.NET.osx-x64"><img src="https://buildstats.info/nuget/MKL.NET.osx-x64?includePreReleases=true" ></a></td></tr>
<tr><td>libraries:</td></tr>
<tr><td>MKL.NET.Matrix</td><td><a href="https://www.nuget.org/packages/MKL.NET.Matrix"><img src="https://buildstats.info/nuget/MKL.NET.Matrix?includePreReleases=true" ></td></tr>
</table>

## Rationale

- Use freely available Intel MKL packages repackaged to work for each runtime.
- The MKL.NET API is just a thin .NET wrapper around the native API keeping the syntax as close as possible.
- The project is well defined with no business logic and could benefit from external input.
- Cross platform testing is easy and free using Github actions.
- MKL.NET native packages can just be referenced for needed runtimes at library or application level.

## MKL.NET.Matrix

- Performance and memory optimised matrix algebra library.
- Scale and Transpose deferred and unlikely to result in allocations.
- ArrayPool underlying memory model using IDisposable and Finalizers.
- Future optimisations likely include bespoke ArrayPool, Pinned Object Heap, and pinning optimisations.

The following examples only create one new matrix (using ArrayPool) without mutating inputs.
```csharp
public static matrix Example1(matrix m)
{
    return 0.5 * m * m.T;
}

public static matrix Example2(matrix a, matrix b, double w)
{
    return w * a + (1-w) * b.T;
}

public static matrix Example3(matrix m)
{
    return Matrix.Round(100.0 * m.T);
}

public static matrix Example4(matrix m)
{
    matrix r = Example1(m);
    Matrix.Inplace.Log1p(r);
    return r;
}
```