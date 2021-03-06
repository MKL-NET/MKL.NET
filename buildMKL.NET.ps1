dotnet build .\MKL.NET\MKL.NET.csproj -c Release -r win-x64
dotnet build .\MKL.NET\MKL.NET.csproj -c Release -r win-x86
dotnet build .\MKL.NET\MKL.NET.csproj -c Release -r linux-x64 -p:OS=LINUX
dotnet build .\MKL.NET\MKL.NET.csproj -c Release -r linux-x86 -p:OS=LINUX
dotnet build .\MKL.NET\MKL.NET.csproj -c Release -r osx-x64 -p:OS=OSX
dotnet pack MKL.NET -c Release -o packages -p:OS=REF