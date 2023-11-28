using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Express;

namespace IFC4.Generators;

internal static class Extensions
{
    internal static string fieldName(this string x)
    {
        return char.ToLowerInvariant(x[0]) + x.Substring(1);
    }
}

public class JavaLanguageGenerator : ILanguageGenerator
{
    private readonly string package;

    public JavaLanguageGenerator(string package)
    {
        this.package = package;
    }

    public Dictionary<string, SelectType> SelectData { get; set; }
    public Dictionary<string, List<string>> InversedSelectData { get; set; }
    public Dictionary<string, EnumType> EnumData { get; set; }
    public Dictionary<string, WrapperType> WrapperData { get; set; }
    public Dictionary<string, List<InverseAttr>> InverseAttrs { get; set; }
    public ExpressListener Listener { get; set; }

    public string AttributeDataType(bool isCollection, int rank, string type, bool isGeneric)
    {
        if (isCollection)
            return
                $"{string.Join("", Enumerable.Repeat("Collection<", rank))}{type}{string.Join("", Enumerable.Repeat(">", rank))}";

        // Item is used in functions.
        if (isGeneric) return "T";

        // https://github.com/ikeough/IFC-gen/issues/25
        if (type == "IfcSiUnitName") return "IfcSIUnitName";

        return type;
    }

    public string AttributeDataString(AttributeData data)
    {
        var prop = string.Empty;
        if (data.IsDerived)
        {
            // var isNew = data.IsDerived && data.HidesParentAttributeOfSameName ? "new " : string.Empty;
            var name = data.Name;
            prop = $@"
        public {data.Type} get{name}() {{throw new UnsupportedOperationException(""Derived property logic has been implemented for {name}."");}} // derived";
        }
        else
        {
            var tags = new List<string>();
            if (data.IsOptional) tags.Add("optional");
            if (data.IsInverse) tags.Add("inverse");

            prop = $"\tprotected {data.Type} {data.Name.fieldName()};\n";
            prop += $"\tpublic {data.Type} get{data.Name}() {{ return this.{data.Name.fieldName()}; }}\n";
            prop += $"\tpublic void set{data.Name}({data.Type} value) {{ this.{data.Name.fieldName()} = value; }}";
            if (tags.Any()) prop += $" // {string.Join(", ", tags)}";
        }

        return prop;
    }

    public string AttributeStepString(AttributeData data, bool isDerivedInChild)
    {
        var step =
            $"\t\tparameters.add({data.Name.fieldName()} != null ? StepUtils.toStepValue({data.Name.fieldName()}) : \"$\");";

        if (isDerivedInChild)
        {
            step = "\t\tparameters.add(\"*\");";
            return step;
        }

        // TODO: Not all enums are called xxxEnum. This emits code which causes 
        // 'never equal to null' errors. Find a better way to handle enums which don't
        // end in 'enum'.
        if (data.Type.EndsWith("Enum") | (data.Type == "bool") | (data.Type == "int") | (data.Type == "double"))
            step = $"\t\tparameters.add(StepUtils.toStepValue({data.Name.fieldName()}));";
        return step;
    }

    public string SimpleTypeString(WrapperType data)
    {
        //
        var wrapped = WrappedType(data);
        var constructor = new StringBuilder();
        if (isPrimitiveType(data.WrappedType))
        {
            constructor.AppendLine($"public {data.Name}({WrappedType(data)} value){{ this.value = value; }}");
        }
        else if (data.IsCollectionType)
        {
            //ex) Collection<Long>

            //ex) Collection<SomeSimpleType>
        }


        var constructorTokens = $@"
    public static final List<List<TypeToken>> CONSTRUCTORS = new ArrayList<>();
    static {{
        List<TypeToken> c1 = new ArrayList<>();
        c1.add(new TypeToken<{WrappedType(data)}>() {{}});
        CONSTRUCTORS.add(c1);
    }}";

        var result =
            $@"{package};

import com.google.common.reflect.TypeToken;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.ArrayList;
	
/*
{data.Schema}
@link http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/{data.Name.ToLower()}.htm
*/
public class {data.Name} extends BaseIfc {GetSelectImplementsString(data.Name, isWrapped: true)}{{
{constructorTokens}
    protected {WrappedType(data)} value;

    public {WrappedType(data)} getValue() {{
        return this.value;
    }}

    public {data.Name}({WrappedType(data)} value){{ this.value = value; }}	

    @Override
    public String toString(){{ return String.valueOf(this.value); }}

    public String toStepValue(boolean isSelectOption){{
        if(isSelectOption) {{ 
            return getClass().getSimpleName().toUpperCase() + ""("" + StepUtils.toStepValue(this.value, isSelectOption) + "")"";
        }} else {{
            return StepUtils.toStepValue(this.value, isSelectOption); 
        }}
    }}
}}
";
        return result;
    }

    public string EnumTypeString(EnumType data)
    {
        var result =
            $@"{package};

import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.ArrayList;
	
/*
{data.Schema}
@link http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/{data.Name.ToLower()}.htm
*/
public enum {data.Name} {{{string.Join(",", data.Values)}}}
";
        return result;
    }

    public string SelectTypeString(SelectType data)
    {
        var constructors = new StringBuilder();
        foreach (var value in data.Values)
        {
            // There is one select in IFC that 
            // has an option which is an enum, which
            // does not inherit from BaseIfc.
            if (value == "IfcNullStyle") continue;

            constructors.AppendLine($"\tpublic {data.Name}({value} choice){{ this.choice = choice; }}");
        }

        var result =
            $@"{package};

import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.ArrayList;
	
/*
{data.Schema}
@link http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/{data.Name.ToLower()}.htm
*/
public interface {data.Name} {GetSelectImplementsString(data.Name, false, true)}{{
}}
";
        return result;
    }

    public string EntityString(Entity data)
    {
        var super = "BaseIfc";
        if (data.Subs.Any()) super = data.Subs[0].Name;

        var modifier = data.IsAbstract ? "abstract class" : "class";
        
        //todo process relationship data
        var processRelationship = "";
        var callProcessRelationship = "";
            
        if (Listener.InverseAttrData.ContainsKey(data.Name))
        {
            var attrs = Listener.InverseAttrData[data.Name];
            var attrProcess = new List<string>();
            var sample = "";
            foreach (var attr in attrs)
            {
                var inverseAttrTypeData = data.Attributes.Find(x => x.Name == attr.inverseAttrName);
                var targetData = (Entity)Listener.TypeData[attr.entityName];
                var targetAttrTypeData = targetData.Attributes.Find(x => x.Name == attr.name);
                if (inverseAttrTypeData.IsCollection)
                {
                    if (targetAttrTypeData.IsCollection)
                    {
                        var process = $@"
if (this.{inverseAttrTypeData.ParameterName} != null) {{
    for ({inverseAttrTypeData.type} x : this.{inverseAttrTypeData.ParameterName}) {{
        if (x instanceof {attr.entityName})
            (({attr.entityName})x).{targetAttrTypeData.ParameterName}.add(this);
    }}
}}";
                        attrProcess.Add(process);
                    }
                    else
                    {
                        var process = $@"
if (this.{inverseAttrTypeData.ParameterName} != null) {{
    for ({inverseAttrTypeData.type} x : this.{inverseAttrTypeData.ParameterName}) {{
        if (x instanceof {attr.entityName})
            (({attr.entityName})x).{targetAttrTypeData.ParameterName} = this;
    }}
}}";
                        attrProcess.Add(process);
                    }
                }
                else
                {
                    if (targetAttrTypeData.IsCollection)
                    {
                        var process = $@"
if (this.{inverseAttrTypeData.ParameterName} != null) {{
    if (this.{inverseAttrTypeData.ParameterName} instanceof {attr.entityName})
        (({attr.entityName})this.{inverseAttrTypeData.ParameterName}).{targetAttrTypeData.ParameterName}.add(this);
}}";
                        attrProcess.Add(process);
                    }
                    else
                    {
                        var process = $@"
if (this.{inverseAttrTypeData.ParameterName} != null) {{
    if (this.{inverseAttrTypeData.ParameterName} instanceof {attr.entityName})
        (({attr.entityName})this.{inverseAttrTypeData.ParameterName}).{targetAttrTypeData.ParameterName} = this;
}}";
                        attrProcess.Add(process);
                    }
                }
            }

            var allProcessAssignments = string.Join(
                "\n",
                attrProcess.SelectMany(x => x.Split("\n")
                    .Select(x => "\t\t" + x)
                ));
            processRelationship = $@"
    private void set{data.Name}Relationship() {{
{allProcessAssignments}
    }}";
            
            callProcessRelationship = $"this.set{data.Name}Relationship();";
        }
        

        var constructorTokens = "";
        if (!data.IsAbstract)
        {
            var constructorTokensBuilder = new StringBuilder();
            var requiredConstructor = EntityConstructorTypes(data, false);
            if (requiredConstructor.Count() != 0)
            {
                constructorTokensBuilder.AppendLine("\t\tList<TypeToken> c1 = new ArrayList<>();");
                foreach (var x in requiredConstructor)
                    constructorTokensBuilder.AppendLine($"\t\tc1.add(new TypeToken<{x}>() {{}});");
                constructorTokensBuilder.AppendLine("\t\tCONSTRUCTORS.add(c1);");
            }

            var allConstructorTypes = EntityConstructorTypes(data, true);
            if (allConstructorTypes.Count() != 0 && !requiredConstructor.SequenceEqual(allConstructorTypes))
            {
                constructorTokensBuilder.AppendLine("\t\tList<TypeToken> c2 = new ArrayList<>();");
                foreach (var x in allConstructorTypes)
                    constructorTokensBuilder.AppendLine($"\t\tc2.add(new TypeToken<{x}>() {{}});");
                constructorTokensBuilder.AppendLine("\t\tCONSTRUCTORS.add(c2);");
            }

            constructorTokens = $@"
    public static final List<List<TypeToken>> CONSTRUCTORS = new ArrayList<>();
    static {{
{constructorTokensBuilder}
    }}";
        }

        // Create two constructors, one which includes optional parameters and 
        // one which does not. We need to check whether any of the parent types
        // have optional attributes as well, to avoid the case where the current type
        // doesn't have optional parameters, but a base type does.
        string constructors;
        if (data.ParentsAndSelf().SelectMany(e => e.Attributes.Where(a => a.IsOptional)).Any())
            constructors = $@"
    /// <summary>
    /// Construct a {data.Name} with all required attributes.
    /// </summary>
	public {data.Name}({ConstructorParams(data, false)}) {{

        super({BaseConstructorParams(data, false)});
{Allocations(data, true)}
{Assignments(data, false)}
        {callProcessRelationship}
		}}
    /// <summary>
    /// Construct a {data.Name} with required and optional attributes.
    /// </summary>
    public {data.Name}({ConstructorParams(data, true)}) {{
        super({BaseConstructorParams(data, true)});
{Allocations(data, false)}
{Assignments(data, true)}
        {callProcessRelationship}
		}}";
        else
            constructors = $@"
    /// <summary>
    /// Construct a {data.Name} with all required attributes.
    /// </summary>
    public {data.Name}({ConstructorParams(data, false)}) {{
        super({BaseConstructorParams(data, false)});
{Allocations(data, true)}
{Assignments(data, false)}
        {callProcessRelationship}
		}}";


        var classStr = $@"{package};

import com.google.common.reflect.TypeToken;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.ArrayList;
	
/*
{data.Schema}
@link http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/{data.Name.ToLower()}.htm
*/
public {modifier} {data.Name} extends {super} {GetSelectImplementsString(data.Name)}{{
{data.Properties(SelectData)}
{constructorTokens}
{constructors}
{StepParameters(data)}
{processRelationship}
}}
";
        return classStr;
    }

    public string FileExtension => "java";

    public string ParseSimpleType(ExpressParser.SimpleTypeContext context)
    {
        var type = string.Empty;
        if (context.binaryType() != null)
            type = "byte[]";
        else if (context.booleanType() != null)
            type = "Boolean";
        else if (context.integerType() != null)
            type = "Long";
        else if (context.logicalType() != null)
            type = "Boolean";
        else if (context.numberType() != null)
            type = "Double";
        else if (context.realType() != null)
            type = "Double";
        else if (context.stringType() != null) type = "String";
        return type;
    }

    public void GenerateManifest(string directory, IEnumerable<string> names,
        Dictionary<string, TypeData> types)
    {
        var cachePutBuilder = new StringBuilder();
        foreach (var name in names) cachePutBuilder.AppendLine($"\t\tcache.put(\"{name.ToUpper()}\", {name}.class);");

        var classStr = $@"{package};

import com.google.common.reflect.TypeToken;
import com.howbuild.ifc.DeserializeException;
import java.lang.reflect.Field;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
	
public class IfcRegistry {{
    private static final Map<String, Class<?>> cache = new HashMap<>();

    static {{
{cachePutBuilder}
    }}

    public static Class<?> getClass(String className) {{
        return cache.get(className.toUpperCase());
    }}

	public static List<TypeToken> getTypeTokens(Class clazz, int paramSize) {{
		try {{
			Field field = clazz.getDeclaredField(""CONSTRUCTORS"");
			List<List<TypeToken>> tokens = (List<List<TypeToken>>) field.get(null);
			for (List<TypeToken> token : tokens) {{
				if (token.size() == paramSize)
					return token;
			}}

			return null;
		}} catch (Exception e) {{
			throw new DeserializeException(""No CONSTRUCTOR field found in "" + clazz.getName(), e);
		}}
	}}
}}
";
        var path = Path.Combine(directory, "IfcRegistry.java");
        File.WriteAllText(path, classStr);
    }

    private bool isPrimitiveType(string type)
    {
        return type is "byte[]" or "Boolean" or "Long" or "Double";
    }

    public string Assignment(AttributeData data)
    {
        return $"\t\tthis.{data.Name.fieldName()} = {data.ParameterName};";
    }

    public string Allocation(AttributeData data)
    {
        if (data.IsCollection)
        {
            var dataType = data.Type;
            if (dataType.StartsWith("Collection")) dataType = "ArrayList<>";
            return $"\t\tthis.{data.Name.fieldName()} = new {dataType}();";
        }

        return string.Empty;
    }

    private string WrappedType(WrapperType data)
    {
        if (data.IsCollectionType)
            return
                $"{string.Join("", Enumerable.Repeat("Collection<", data.Rank))}{data.WrappedType}{string.Join("", Enumerable.Repeat(">", data.Rank))}";

        return data.WrappedType;
    }

    public string EntityConstructorParams(Entity data, bool includeOptional)
    {
        // Constructor parameters include the union of this type's attributes and all super type attributes.
        // A constructor parameter is created for every attribute which does not derive
        // from IFCRelationship.

        var parents = data.ParentsAndSelf().Reverse();
        var attrs = parents.SelectMany(p => p.Attributes);

        if (!attrs.Any()) return string.Empty;

        var validAttrs = includeOptional ? AttributesWithOptional(attrs) : AttributesWithoutOptional(attrs);

        return string.Join(",", validAttrs.Select(a => $"{a.Type} {a.ParameterName}"));
    }

    public List<string> EntityConstructorTypes(Entity data, bool includeOptional)
    {
        // Constructor parameters include the union of this type's attributes and all super type attributes.
        // A constructor parameter is created for every attribute which does not derive
        // from IFCRelationship.

        var parents = data.ParentsAndSelf().Reverse();
        var attrs = parents.SelectMany(p => p.Attributes);

        var validAttrs = includeOptional ? AttributesWithOptional(attrs) : AttributesWithoutOptional(attrs);

        return validAttrs.Select(a => a.Type).ToList();
    }

    public string EntityBaseConstructorParams(Entity data, bool includeOptional)
    {
        // Base constructor parameters include the union of all super type attributes.
        var parents = data.Parents().Reverse();

        var attrs = parents.SelectMany(p => p.Attributes);

        if (!attrs.Any()) return string.Empty;

        var validAttrs = includeOptional ? AttributesWithOptional(attrs) : AttributesWithoutOptional(attrs);

        return string.Join(",", validAttrs.Select(a => $"{a.ParameterName}"));
    }

    public string StepParameters(Entity data)
    {
        if (data.IsAbstract) return string.Empty;

        var stepParameters = $@"
    @Override
    public String getStepParameters() {{
        List<String> parameters = new ArrayList<>();
{data.StepProperties()}
        return String.join("""", parameters);
    }}";
        return stepParameters;
    }

    public string EntityTest(Entity data)
    {
        return string.Empty;
    }

    private string Assignments(Entity entity, bool includeOptional)
    {
        var attrs = includeOptional
            ? AttributesWithOptional(entity.Attributes)
            : AttributesWithoutOptional(entity.Attributes);
        if (!attrs.Any()) return string.Empty;

        var assignBuilder = new StringBuilder();
        foreach (var a in attrs)
        {
            var assign = Assignment(a);
            if (!string.IsNullOrEmpty(assign)) assignBuilder.AppendLine(assign);
        }

        return assignBuilder.ToString();
    }

    private string Allocations(Entity entity, bool includeOptional)
    {
        var allocBuilder = new StringBuilder();

        var attrs = entity.Attributes.Where(a => !a.IsDerived)
            .Where(a => a.IsInverse || (includeOptional && a.IsOptional));

        foreach (var a in attrs)
        {
            var alloc = Allocation(a);
            if (!string.IsNullOrEmpty(alloc)) allocBuilder.AppendLine(alloc);
        }

        return allocBuilder.ToString();
    }

    internal IEnumerable<AttributeData> AttributesWithOptional(IEnumerable<AttributeData> ad)
    {
        return ad.Where(a => !a.IsInverse)
            .Where(a => !a.IsDerived);
    }

    internal IEnumerable<AttributeData> AttributesWithoutOptional(IEnumerable<AttributeData> ad)
    {
        return ad.Where(a => !a.IsInverse)
            .Where(a => !a.IsDerived)
            .Where(a => !a.IsOptional);
    }

    /// <summary>
    ///     Return a set of constructor parameters in the form 'Type name1, Type name2'
    /// </summary>
    /// <returns></returns>
    private string ConstructorParams(Entity data, bool includeOptional)
    {
        return EntityConstructorParams(data, includeOptional);
    }

    /// <summary>
    ///     Return a set of constructor params in the form `name1, name2`.
    /// </summary>
    /// <returns></returns>
    private string BaseConstructorParams(Entity data, bool includeOptional)
    {
        return EntityBaseConstructorParams(data, includeOptional);
    }

    private string GetSelectImplementsString(string type, bool isInterface = true, bool isSelect = false,
        bool isWrapped = false)
    {
        var interfaces = InversedSelectData.GetValueOrDefault(type, new List<string>());
        if (!isSelect && (interfaces == null || interfaces.Count == 0)) return "";

        if (isSelect)
        {
            interfaces.Add("Select");
            interfaces.Add("ConvertibleToStep");
        }

        if (isWrapped) interfaces.Add("SimpleType");

        if (isInterface)
            return $"implements {string.Join(", ", interfaces)} ";
        return $"extends {string.Join(", ", interfaces)} ";
    }
}