dotnet build MKL.NET -c Release -r win-x64 -p:MKLNET_RID=win-x64
dotnet build MKL.NET -c Release -r win-x86 -p:MKLNET_RID=win-x86
dotnet build MKL.NET -c Release -r linux-x64 -p:MKLNET_RID=linux-x64
dotnet build MKL.NET -c Release -r linux-x86 -p:MKLNET_RID=linux-x86
dotnet build MKL.NET -c Release -r osx-x64 -p:MKLNET_RID=osx-x64
dotnet pack MKL.NET -c Release -o packages -p:MKLNET_RID=ref