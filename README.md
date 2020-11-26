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
- Scale and Transpose deferred and unlikely to result in allocations (Can perform these together for +, *, and inplace for functions).
- ArrayPool underlying memory model using IDisposable and Finalizers.
- Uses the Pinned Object Heap for net5.0.

The following examples only create one new matrix (using ArrayPool) without mutating inputs.
```csharp
public static matrix Example1(matrix m)
{
    return 0.5 * m * m.T;
}

public static matrix Example2(matrix a, matrix b, double w)
{
    return w * a + (1.0 - w) * b.T;
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

Example statistics matrix function:
```csharp
public static (vector, matrix) MeanAndCovariance(matrix samples, vector weights)
{
    if (samples.Rows != weights.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
    var mean = new vector(samples.Cols);
    var cov = new matrix(samples.Cols, samples.Cols);
    var task = Vsl.SSNewTask(samples.Cols, samples.Rows, VslStorage.ROWS, samples.Array, weights.Array);
    ThrowHelper.Check(Vsl.SSEditCovCor(task, mean.Array, cov.Array, VslFormat.FULL, null, VslFormat.FULL));
    ThrowHelper.Check(Vsl.SSCompute(task, VslEstimate.COV, VslMethod.FAST));
    ThrowHelper.Check(Vsl.SSDeleteTask(task));
    return (mean, cov);
}
```

Note: arrays need to be pinned across all MKL function calls when there are multiple as above as MKL stores native pointers and the arrays could be moved between calls.
MKL.NET handles pinning internally unpinning when the task is deleted.
This is a common bug when using MKL from .NET which causes occasional crashes.
