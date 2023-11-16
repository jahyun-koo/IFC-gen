using System.Collections.Generic;
using System.Linq;
using System.Text;
using Express;

namespace IFC4.Generators;

public class JavaFunctionsGenerator : IFunctionsGenerator
{
    private readonly string package;

    public JavaFunctionsGenerator(string package)
    {
        this.package = package;
    }

    public string FileName => "Functions.g.cs";

    public Dictionary<string, SelectType> SelectData { get; set; } = new();

    public string Generate(IEnumerable<FunctionData> functionDatas)
    {
        return $@"
{package};

public static class Functions
{{
    {Functions(functionDatas)}
}}
";
    }

    private static string Functions(IEnumerable<FunctionData> functionDatas)
    {
        var functionsBuilder = new StringBuilder();
        foreach (var f in functionDatas)
        {
            var parameters = string.Join(",", f.Parameters.Select(p => $"{p.Type} {p.ParameterName}"));
            var func = $@"
        public static {f.ReturnType.Type} {f.Name}{(f.ReturnType.IsGeneric ? "<T>" : "")}({parameters})
        {{
            throw new NotImplementedException();
        }}";
            functionsBuilder.AppendLine(func);
        }

        return functionsBuilder.ToString().TrimEnd('\n');
    }
}