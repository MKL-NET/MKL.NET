using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace MKLNET.WrapperGenerator;

[Generator]
public class WrapperGenerator : ISourceGenerator
{
    private static readonly string _version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "na";

    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new UnsafeClassSyntaxReceiver());
    }

    private static ParameterSyntax? GetLengthDropCandidate(MethodDeclarationSyntax mds)
    {
        var candidates = mds.ParameterList.Parameters.Where(p => p.Type is PredefinedTypeSyntax { Keyword: { } keyword }
                                                            && keyword.IsKind(SyntaxKind.IntKeyword)
                                                            && p.Identifier.Text.Length == 1
                                                            ).ToList();

        if (candidates.Count != 1)
        {
            return null;
        }

        return candidates[0];
    }

    private static (ISet<ParameterSyntax> changed, ParameterListSyntax newList)
    TransformParameters(MethodDeclarationSyntax mds, Func<ParameterSyntax, ParameterSyntax?> f)
    {
        var changed = mds.ParameterList.Parameters.Select(ps => f(ps) is null ? null : ps).Where(ps => ps != null).ToImmutableHashSet();
        var newList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(mds.ParameterList.Parameters.Select(ps => f(ps) ?? ps)));

        return (changed!, newList);
    }

    private enum AdditionalTransformation
    {
        ///<summary>Only transform pointers</summary>
        None,
        ///<summary>Drop a single <c>int n</n> parameter. Infer length from first transformed pointer.</summary>
        InferLength,
        ///<summary>Add <c>iniX</c> parameters that act as offsets.</summary>
        AddOffsets
    }

    void WriterTransformedMethod(
        MethodDeclarationSyntax mds, ClassDeclarationSyntax nativeCds,
        (ISet<ParameterSyntax> changed, ParameterListSyntax newList) transformation, StringBuilder sb,
        AdditionalTransformation trafo)
    {
        (ParameterSyntax lengthParam, string takeLengthFrom)? lengthOptions = null;
        ParameterListSyntax parameterList;

        static bool IsOffsettable(ParameterSyntax p) => p.Identifier.Text.Length <= 2 && p.Identifier.Text != "A"; // `param` and `A` do not get `ini` in BLAS

        switch (trafo)
        {
            case AdditionalTransformation.InferLength
                when GetLengthDropCandidate(mds) is { } lengthParam
                && transformation.changed.FirstOrDefault() is { Identifier.Text: { } takeLengthFrom }:
                lengthOptions = (lengthParam, takeLengthFrom);
                sb.Append("\t\t///<remarks>This version infers the length parameter <c>")
                    .Append(lengthParam.Identifier)
                    .Append("</c> from <paramref name=\"")
                    .Append(takeLengthFrom)
                    .AppendLine("\" />'s length.</remarks>");
                var noLen = transformation.newList.Parameters.Where(p => p.Identifier.Text != lengthParam.Identifier.Text);
                parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(noLen));
                break;
            case AdditionalTransformation.InferLength:
                return;
            case AdditionalTransformation.AddOffsets
                when transformation.newList.Parameters.Any(p => p.Identifier.Text.StartsWith("inc")):
                var withIni = transformation.newList.Parameters.SelectMany(p =>
                {
                    if (IsOffsettable(p)
                        && transformation.changed.Any(c => c.Identifier.Text == p.Identifier.Text))
                    {
                        return new[] {p,
                        SyntaxFactory.Parameter(
                            SyntaxFactory.Identifier("ini"+p.Identifier.Text))
                            .WithType(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword)))};
                    }

                    return new[] { p };
                });
                parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(withIni));
                sb.AppendLine("\t\t///<remarks>This version takes offsets in the form of <c>iniX</c> arguments. Consider using the Span version with slicing instead.</remarks>");
                break;
            case AdditionalTransformation.AddOffsets:
                return;
            default:
                parameterList = transformation.newList;
                break;
        }

        sb.Append("\t\t///<summary>Calls the MKL function <c>").Append(mds.Identifier.Text).AppendLine("</c> by pinning the given data during the computation.</summary>");
        sb.AppendLine("\t\t[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]");
        sb.Append("\t\tpublic static ")
            .Append(mds.ReturnType)
            .Append(' ')
            .Append(trafo == AdditionalTransformation.AddOffsets ? mds.Identifier.Text.TrimEnd('I') : mds.Identifier)
            .Append(parameterList.NormalizeWhitespace())
            .AppendLine();
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tunsafe");
        sb.AppendLine("\t\t\t{");
        foreach (var changedParam in transformation.changed)
        {
            if (trafo == AdditionalTransformation.AddOffsets && IsOffsettable(changedParam))
            {
                sb.Append("\t\t\t\tfixed(").Append(changedParam.Type).Append(' ').Append(changedParam.Identifier).Append("Pinned = &").Append(changedParam.Identifier).Append("[ini").Append(changedParam.Identifier).AppendLine("])");
            }
            else
            {
                sb.Append("\t\t\t\tfixed(").Append(changedParam.Type).Append(' ').Append(changedParam.Identifier).Append("Pinned = ").Append(changedParam.Identifier).AppendLine(")");
            }
        }
        sb.AppendLine("\t\t\t\t{");
        var maybeReturn = mds.ReturnType is PredefinedTypeSyntax { Keyword: { } keyword }
                            && keyword.IsKind(SyntaxKind.VoidKeyword)
                            ? "" : "return ";
        sb.Append("\t\t\t\t\t").Append(maybeReturn).Append(nativeCds.Identifier).Append('.').Append(mds.Identifier).Append('(');

        var callList = string.Join(", ", mds.ParameterList.Parameters
            .Select(ps => ps.Modifiers.ToString() + " " + (
                transformation.changed.Contains(ps)
                ? $"{ps.Identifier}Pinned"
                : ps == lengthOptions?.lengthParam
                    ? $"{lengthOptions?.takeLengthFrom}.Length"
                    : ps.Identifier.ValueText)));

        sb.Append(callList);
        sb.AppendLine(");"); // End of call
        sb.AppendLine("\t\t\t\t}"); // End of fixed
        sb.AppendLine("\t\t\t}"); // End of unsafe
        sb.AppendLine("\t\t}"); // End of method
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxReceiver is UnsafeClassSyntaxReceiver { Classes: { } classes })
        {
            foreach (var (parentCds, nativeCds) in classes)
            {
                ExecuteOneClass(context, parentCds, nativeCds);
            }
        }
    }

    public void ExecuteOneClass(GeneratorExecutionContext context, ClassDeclarationSyntax parentCds, ClassDeclarationSyntax nativeCds)
    {
        var semantics = context.Compilation.GetSemanticModel(parentCds.SyntaxTree);
        var parentClassSymbol = semantics.GetDeclaredSymbol(parentCds)!;

        var sb = new StringBuilder("// <auto-generated/>");

        if (parentCds.SyntaxTree.GetRoot() is CompilationUnitSyntax unit)
        {
            sb.AppendLine(unit.Usings.ToString());
            sb.AppendLine();
        }

        sb.Append("namespace ").Append(parentClassSymbol.ContainingNamespace).AppendLine();
        sb.AppendLine("{");
        sb.Append("\t[global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"MKL.NET\", \"").Append(_version).AppendLine("\")]");
        sb.Append("\tpartial class ").AppendLine(parentClassSymbol.Name);
        sb.AppendLine("\t{");

        foreach (var member in nativeCds.Members)
        {
            if (member is MethodDeclarationSyntax mds)
            {
                // Array version, ignore [In]
                var arrayParams = TransformParameters(mds,
                originalParam => originalParam.Type is PointerTypeSyntax pts
                    ? originalParam
                        .WithType(
                            SyntaxFactory.ArrayType
                            (
                                pts.ElementType,
                                SyntaxFactory.List(new[] { SyntaxFactory.ArrayRankSpecifier() })
                            )
                        .WithTrailingTrivia(SyntaxFactory.Whitespace(" ")))
                        .WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>())
                    : null);

                // Span version, use [In] on pointer to mark possible read-only spans
                var inAttribute = semantics.Compilation.GetTypeByMetadataName(typeof(System.Runtime.InteropServices.InAttribute).FullName);
                var spanParams = TransformParameters(mds,
                originalParam =>
                {
                    if (originalParam.Type is not PointerTypeSyntax pts)
                    {
                        return null;
                    }

                    var attributeTypes = originalParam.AttributeLists
                        .SelectMany(al => al.Attributes)
                        .Select(a => semantics.GetTypeInfo(a).Type)
                        .ToImmutableHashSet(SymbolEqualityComparer.Default);

                    return originalParam
                        .WithType(
                            SyntaxFactory.GenericName
                            (
                                SyntaxFactory.Identifier(
                                    attributeTypes.Contains(inAttribute)
                                    ? "global::System.ReadOnlySpan"
                                    : "global::System.Span"
                                ),
                                SyntaxFactory.TypeArgumentList(SyntaxFactory.SeparatedList(new[] { pts.ElementType }))
                            )
                            .WithTrailingTrivia(SyntaxFactory.Whitespace(" ")))
                        .WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>());
                });

                var lengthParam = GetLengthDropCandidate(mds);
                WriterTransformedMethod(mds, nativeCds, arrayParams, sb, AdditionalTransformation.None);

                // Dropping the length parameter is nice, but might not make sense on matrix stuff
                if (parentCds.Identifier.Text != "Lapack")
                {
                    WriterTransformedMethod(mds, nativeCds, arrayParams, sb, AdditionalTransformation.InferLength);
                }

                // VML and BLAS have `ini` versions (that are not needed with Span anymore)
                if (parentCds.Identifier.Text == "Blas" || (parentCds.Identifier.Text == "Vml" && mds.Identifier.Text.EndsWith("I")))
                {
                    WriterTransformedMethod(mds, nativeCds, arrayParams, sb, AdditionalTransformation.AddOffsets);
                }

                sb.AppendLine();

                WriterTransformedMethod(mds, nativeCds, spanParams, sb, AdditionalTransformation.None);

                if (parentCds.Identifier.Text != "Lapack")
                {
                    WriterTransformedMethod(mds, nativeCds, spanParams, sb, AdditionalTransformation.InferLength);
                }

                sb.AppendLine();
            }
        }

        sb.AppendLine("\t}"); // End of class
        sb.AppendLine("}"); // End of namespace

        var s = sb.ToString();

        context.AddSource($"{parentCds.Identifier}.Wrappers.g.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
    }
}

internal class UnsafeClassSyntaxReceiver : ISyntaxReceiver
{
    public List<(ClassDeclarationSyntax parent, ClassDeclarationSyntax native)> Classes { get; } = new();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        // we match any `static class Unsafe` nested in a parent class which is static and partial
        if (syntaxNode is ClassDeclarationSyntax
            {
                Identifier.ValueText: "Unsafe",
                Modifiers: { } childModifiers,
                Parent: ClassDeclarationSyntax { Modifiers: { } parentModifiers } parentCds
            } unsafeCds
            && childModifiers.Any(SyntaxKind.StaticKeyword)
            && parentModifiers.Any(SyntaxKind.PartialKeyword)
            && parentModifiers.Any(SyntaxKind.StaticKeyword))
        {
            Classes.Add((parentCds, unsafeCds));
        }
    }
}