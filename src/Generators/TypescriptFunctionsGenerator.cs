using System.Collections.Generic;
using System.Linq;
using System.Text;
using Express;

namespace IFC4.Generators;

public class TypescriptFunctionsGenerator : IFunctionsGenerator
{
    public Dictionary<string, SelectType> SelectData { get; set; } = new();

    public string FileName => "Functions.g.ts";

    public string Generate(IEnumerable<FunctionData> functionDatas)
    {
        var importBuilder = new StringBuilder();

        foreach (var d in Dependencies(functionDatas)) importBuilder.AppendLine($"import {{{d}}} from \"./{d}.g\"");

        return $@"
{importBuilder}
export class Functions
{{
    {Functions(functionDatas)}
}}";
    }

    private static string Functions(IEnumerable<FunctionData> functionDatas)
    {
        var functionsBuilder = new StringBuilder();
        foreach (var f in functionDatas)
        {
            var parameters = string.Join(",", f.Parameters.Select(p => $"{p.ParameterName}: {p.Type}"));
            var func = $@"
    static {f.Name}{(f.ReturnType.IsGeneric ? "<T>" : "")}({parameters}) : {f.ReturnType.Type} {{
        throw ""This function is not yet implemented.""
    }}";
            functionsBuilder.AppendLine(func);
        }

        return functionsBuilder.ToString().TrimEnd('\n');
    }

    private IEnumerable<string> Dependencies(IEnumerable<FunctionData> functionDatas)
    {
        var result = new List<string>();
        foreach (var fd in functionDatas)
        {
            result.AddRange(ExpandPossibleTypes(fd.ReturnType.type));
            result.AddRange(fd.Parameters.SelectMany(p => ExpandPossibleTypes(p.type)));
        }

        var existingTypes = new List<string> { "boolean", "number", "string", "boolean", "Uint8Array", "T", "Item" };
        var types = result.Distinct().Where(t => !existingTypes.Contains(t));
        types = types.Select(t => t == "IfcSiUnitName" ? "IfcSIUnitName" : t);

        return types;
    }

    private IEnumerable<string> ExpandPossibleTypes(string baseType)
    {
        if (!SelectData.ContainsKey(baseType))
            // return right away, it's not a select
            return new List<string> { baseType };

        var values = SelectData[baseType].Values;
        var result = new List<string>();
        foreach (var v in values) result.AddRange(ExpandPossibleTypes(v));

        return result;
    }
}