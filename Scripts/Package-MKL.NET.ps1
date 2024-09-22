dotnet build MKL.NET -c Release -r win-x64
dotnet build MKL.NET -c Release -r linux-x64
dotnet build MKL.NET -c Release -r osx-x64
dotnet build MKL.NET -c Release -r osx-x86 # The ref assembly
dotnet pack MKL.NET -c Release -o packages -p:NOCONT=true
dotnet pack MKL.NET.Matrix -c Release -o packages -p:NORID=true
dotnet pack MKL.NET.Optimization -c Release -o packages -p:NORID=true
dotnet pack MKL.NET.Statistics -c Release -o packages -p:NORID=true
