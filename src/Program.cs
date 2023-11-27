using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Express;
using IFC4.Generators;
using NDesk.Options;

namespace IFC.Generate;

internal class Program
{
    private static string language;
    private static string outDir;
    private static string expressPath;
    private static bool showHelp;
    private static bool outputTokens;
    private static string javaPackage;

    private static void Main(string[] args)
    {
        ParseOptions(args);
        if (showHelp) return;

        var generators = new List<Tuple<ILanguageGenerator, IFunctionsGenerator>>();

        if (language == "csharp")
        {
            generators.Add(new Tuple<ILanguageGenerator, IFunctionsGenerator>(
                new CsharpLanguageGenerator(), new CsharpFunctionsGenerator()));
        }
        else if (language == "proto")
        {
            generators.Add(new Tuple<ILanguageGenerator, IFunctionsGenerator>(new ProtobufGenerator(), null));
        }
        else if (language == "ts")
        {
            generators.Add(new Tuple<ILanguageGenerator, IFunctionsGenerator>(new TypescriptGenerator(),
                new TypescriptFunctionsGenerator()));
        }
        else if (language == "java")
        {
            // read from lang/java/*.java, and add package header to each file
            var baseDirectory = AppContext.BaseDirectory;
            var package = "package " + javaPackage + ";";
            while (true)
            {
                if (Directory.GetDirectories(baseDirectory, "grammar").Length > 0 ||
                    Directory.GetDirectories(baseDirectory, "lang").Length > 0)
                    // .csproj 또는 .sln 파일이 있는 디렉토리를 찾으면 멈춥니다.
                    break;
                baseDirectory = Directory.GetParent(baseDirectory).FullName; // 상위 디렉토리로 이동
            }

            var sourceDirectory = Path.Combine(baseDirectory, @"lang/java/src");
            var files = Directory.EnumerateFiles(sourceDirectory, "*.java", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var txt = File.ReadAllLines(file).ToList();
                txt.Insert(0, package);
                var destFile = Path.Combine(outDir, file.Substring(sourceDirectory.Length + 1));
                Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                File.WriteAllLines(destFile, txt);
            }

            //generate
            var generator = new JavaLanguageGenerator(package);
            var functionsGenerator = new JavaFunctionsGenerator(package);
            generators.Add(new Tuple<ILanguageGenerator, IFunctionsGenerator>(generator, functionsGenerator));
        }

        using (var fs = new FileStream(expressPath, FileMode.Open))
        {
            var input = new AntlrInputStream(fs);
            var lexer = new ExpressLexer(input);
            var tokens = new CommonTokenStream(lexer);

            var parser = new ExpressParser(tokens);
            parser.BuildParseTree = true;

            var tree = parser.schemaDecl();
            var walker = new ParseTreeWalker();

            foreach (var generator in generators)
            {
                var listener = new ExpressListener(generator.Item1);
                walker.Walk(listener, tree);
                Generate(listener, outDir, generator.Item1, generator.Item2);
            }

            if (!outputTokens) return;

            var tokenStr = new StringBuilder();
            foreach (var t in tokens.GetTokens()) tokenStr.AppendLine(t.ToString());
            Console.WriteLine(tokenStr);
        }
    }

    private static void Generate(ExpressListener listener, string outDir,
        ILanguageGenerator generator, IFunctionsGenerator functionsGenerator)
    {
        var names = new List<string>();

        var sd = listener.TypeData.Where(kvp => kvp.Value is SelectType).Select(v => new { v.Key, v.Value })
            .ToDictionary(t => t.Key, t => (SelectType)t.Value);
        generator.SelectData = sd;

        var wd = listener.TypeData.Where(kvp => kvp.Value is WrapperType).Select(v => new { v.Key, v.Value })
            .ToDictionary(t => t.Key, t => (WrapperType)t.Value);
        generator.WrapperData = wd;

        var inversedSd = sd.SelectMany(kvp => kvp.Value.Values.Select(v => new { kvp.Key, Value = v }))
            .GroupBy(x => x.Value, x => x.Key)
            .ToDictionary(grp => grp.Key, grp => grp.ToList());

        generator.InversedSelectData = inversedSd;

        var ed = listener.TypeData.Where(kvp => kvp.Value is EnumType).Select(v => new { v.Key, v.Value })
            .ToDictionary(t => t.Key, t => (EnumType)t.Value);
        generator.EnumData = ed;

        generator.InverseAttrs = listener.InverseAttrData;
        generator.Listener = listener;

        foreach (var kvp in listener.TypeData)
        {
            var td = kvp.Value;
            File.WriteAllText(Path.Combine(outDir, $"{td.Name}.{generator.FileExtension}"), td.ToString());
            names.Add(td.Name);
        }

        generator.GenerateManifest(outDir, names, listener.TypeData);

        if (functionsGenerator != null)
        {
            functionsGenerator.SelectData = sd;
            var functionsPath = Path.Combine(outDir, functionsGenerator.FileName);
            File.WriteAllText(functionsPath, functionsGenerator.Generate(listener.FunctionData.Values));
        }
    }

    private static void ParseOptions(string[] args)
    {
        var p = new OptionSet
        {
            { "e|express=", "The path the express schema.", v => expressPath = v },
            { "o|output=", "The directory in which the code is generated.", v => outDir = v },
            { "l|language=", "The target language (csharp)", v => language = v },
            { "p|tokens", "Output tokens to stdout during parsing.", v => outputTokens = v != null },
            { "j|java-package=", "target package (when java)", v => javaPackage = v },
            { "h|help", v => showHelp = v != null }
        };

        List<string> extra;
        try
        {
            extra = p.Parse(args);
        }
        catch (OptionException e)
        {
            Console.Write("IFC-gen: ");
            Console.WriteLine(e.Message);
            Console.WriteLine("Try `IFC-gen --help' for more information.");
            return;
        }

        if (showHelp) ShowHelp(p);
    }

    private static void ShowHelp(OptionSet p)
    {
        Console.WriteLine("Usage: IFC-gen [OPTIONS]+");
        Console.WriteLine();
        Console.WriteLine("Options:");
        p.WriteOptionDescriptions(Console.Out);
    }
}