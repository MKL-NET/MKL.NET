using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using Xunit;
using FluentAssertions;

namespace MKLNET.WrapperGenerator.Tests
{
    public class GeneratorTest
    {
        [Fact]
        public void GeneratorShouldAcceptPinvokeStatementAndNotProduceErrors()
        {
            var inputCompilation = CreateCompilation(@"
using System.Runtime.InteropServices;

namespace MKLNET;

public static partial class BlasOption2
{
    public static class Unsafe
    {
        [DllImport(""dummy.dll"", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = ""dummy"")]
        public static unsafe extern void dummy(int M, int N,
            int K, double alpha, double* A,
            int lda, double* B, int ldb,
            double beta, double* C, int ldc);

        public static unsafe extern void summy(int N, double* A, double* B);
    }
}
");

            var generator = new MKLNET.WrapperGenerator.WrapperGenerator();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation, out var diagnostics);

            diagnostics.Should().BeEmpty();
            outputCompilation.SyntaxTrees.Should().HaveCount(2); // input and generated
            outputCompilation.GetDiagnostics().Should().BeEmpty();

            var runResult = driver.GetRunResult();

            runResult.GeneratedTrees.Should().HaveCount(1);
            runResult.Diagnostics.Should().BeEmpty();

            var generatorResult = runResult.Results[0];

            generatorResult.Generator.Should().BeSameAs(generator);
            generatorResult.Diagnostics.Should().BeEmpty();
            generatorResult.GeneratedSources.Should().HaveCount(1);
            generatorResult.Exception.Should().BeNull();
        }

        private static Compilation CreateCompilation(string source)
            => CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, allowUnsafe: true, warningLevel: 0));
    }
}