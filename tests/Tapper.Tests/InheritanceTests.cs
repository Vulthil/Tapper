using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Tapper.Test.SourceTypes;
using Tapper.Test.SourceTypes.Space3;
using Tapper.Tests.SourceTypes;
using Tapper.TypeMappers;
using Xunit;
using Xunit.Abstractions;

namespace Tapper.Tests;

public class InheritanceTests
{
    private readonly ITestOutputHelper _output;

    public InheritanceTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Test0()
    {
        var compilation = CompilationSingleton.Compilation;
        var codeGenerator = new TypeScriptCodeGenerator(compilation, Environment.NewLine, 2, SerializerOption.Json, NamingStyle.None, EnumNamingStyle.None, Logger.Empty);

        var type = typeof(InheritanceClass0);
        var typeSymbol = compilation.GetTypeByMetadataName(type.FullName!)!;

        var writer = new CodeWriter();

        codeGenerator.AddType(typeSymbol, ref writer);

        var code = writer.ToString();
        var gt = @"/** Transpiled from Tapper.Test.SourceTypes.InheritanceClass0 */
export type InheritanceClass0 = {
  /** Transpiled from int */
  Value0: number;
}
";

        _output.WriteLine(code);
        _output.WriteLine(gt);

        Assert.Equal(gt, code, ignoreLineEndingDifferences: true);
    }

    [Fact]
    public void Test1()
    {
        var compilation = CompilationSingleton.Compilation;
        var codeGenerator = new TypeScriptCodeGenerator(compilation, Environment.NewLine, 2, SerializerOption.Json, NamingStyle.None, EnumNamingStyle.None, Logger.Empty);

        var type = typeof(InheritanceClass1);
        var typeSymbol = compilation.GetTypeByMetadataName(type.FullName!)!;

        var writer = new CodeWriter();

        codeGenerator.AddType(typeSymbol, ref writer);

        var code = writer.ToString();
        var gt = @"/** Transpiled from Tapper.Test.SourceTypes.InheritanceClass1 */
export type InheritanceClass1 = {
  /** Transpiled from string */
  InheritanceString1: string;
} & InheritanceClass0;
";

        _output.WriteLine(code);
        _output.WriteLine(gt);

        Assert.Equal(gt, code, ignoreLineEndingDifferences: true);
    }

    [Fact]
    public void Test2()
    {
        var compilation = CompilationSingleton.Compilation;
        var codeGenerator = new TypeScriptCodeGenerator(compilation, Environment.NewLine, 2, SerializerOption.Json, NamingStyle.None, EnumNamingStyle.None, Logger.Empty);

        var type = typeof(InheritanceClass2);
        var typeSymbol = compilation.GetTypeByMetadataName(type.FullName!)!;

        var writer = new CodeWriter();

        codeGenerator.AddType(typeSymbol, ref writer);

        var code = writer.ToString();
        var gt = @"/** Transpiled from Tapper.Test.SourceTypes.InheritanceClass2 */
export type InheritanceClass2 = {
  /** Transpiled from string? */
  InheritanceString2?: string;
} & InheritanceClass0;
";

        _output.WriteLine(code);
        _output.WriteLine(gt);

        Assert.Equal(gt, code, ignoreLineEndingDifferences: true);
    }

    [Fact]
    public void Test3()
    {
        var compilation = CompilationSingleton.Compilation;
        var codeGenerator = new TypeScriptCodeGenerator(compilation, Environment.NewLine, 2, SerializerOption.Json, NamingStyle.None, EnumNamingStyle.None, Logger.Empty);

        var type = typeof(Space2.CustomType2);
        var typeSymbol = compilation.GetTypeByMetadataName(type.FullName!)!;

        var writer = new CodeWriter();

        codeGenerator.AddType(typeSymbol, ref writer);

        var code = writer.ToString();
        var gt = @"/** Transpiled from Space2.CustomType2 */
export type CustomType2 = {
  /** Transpiled from float */
  Value2: number;
  /** Transpiled from System.DateTime */
  DateTime2: (Date | string);
} & CustomType1;
";

        _output.WriteLine(code);
        _output.WriteLine(gt);

        Assert.Equal(gt, code, ignoreLineEndingDifferences: true);
    }
}
