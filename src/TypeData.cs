using System.Collections.Generic;
using System.Linq;
using System.Text;
using IFC4.Generators;

namespace Express;

/// <summary>
///     TypeReference stores information about a reference to a type.
/// </summary>
public class TypeReference
{
    protected ILanguageGenerator generator;

    internal string type;

    /// <summary>
    ///     Name will be a type name or a path.
    /// </summary>
    /// <returns></returns>
    public TypeReference(ILanguageGenerator generator, string type, bool isCollection, int rank, bool isGeneric)
    {
        this.generator = generator;
        IsCollection = isCollection;
        Rank = rank;
        IsGeneric = isGeneric;
        this.type = type;
    }

    /// <summary>
    ///     The name of the Type that is referenced.
    /// </summary>
    /// <returns></returns>
    public string Type => generator.AttributeDataType(IsCollection, Rank, type, IsGeneric);

    /// <summary>
    ///     Is this attribute a collection type such as ARRAY, SET, LIST, or BAG?
    /// </summary>
    /// <returns></returns>
    public bool IsCollection { get; }

    /// <summary>
    ///     The dimension of the collection type. Ex: Rank=2 => List<List<T>>
    /// </summary>
    /// <returns></returns>
    public int Rank { get; }

    public bool IsGeneric { get; }
}

/// <summary>
///     ParameterData stores the name and type information for a parameter.
/// </summary>
public class ParameterData : TypeReference
{
    public ParameterData(ILanguageGenerator generator, string name, bool isCollection, int rank, bool isGeneric,
        string type) : base(generator, type, isCollection, rank, isGeneric)
    {
        Name = name;
    }

    public string Name { get; protected set; }

    /// <summary>
    ///     A string representing the parameter corresponding to an attribute's info.
    /// </summary>
    /// <returns></returns>
    public string ParameterName
    {
        get
        {
            var name = Name;
            if (name == "Operator") name = "op";

            return char.ToLowerInvariant(name[0]) + name.Substring(1);
        }
    }
}

/// <summary>
///     AttributeData stores information about type attributes.
/// </summary>
public class AttributeData : ParameterData
{
    public AttributeData(ILanguageGenerator generator, string name, string type, int rank, bool isCollection,
        bool isGeneric, bool isDerived = false, bool isOptional = false, bool isInverse = false) :
        base(generator, name, isCollection, rank, isGeneric, type)
    {
        IsDerived = isDerived;
        IsOptional = isOptional;
        IsInverse = isInverse;

        // A derived attribute which replaces a base class's version of
        // the attribute will have a name that is a path to the 
        // parent class' attribute of the form SELF\IfcNamedUnit.Dimensions.
        if (isDerived && Name.Contains("SELF\\"))
        {
            HidesParentAttributeOfSameName = true;
            Name = Name.Split('.').Last();
        }
    }

    /// <summary>
    ///     Is this attribute INVERSE?
    /// </summary>
    /// <returns></returns>
    public bool IsInverse { get; }

    /// <summary>
    ///     Is this attribute DERIVED?
    /// </summary>
    /// <returns></returns>
    public bool IsDerived { get; }

    /// <summary>
    ///     Does this attribute hide a parent's attribute by
    ///     the same name?
    /// </summary>
    /// <returns></returns>
    public bool HidesParentAttributeOfSameName { get; }

    /// <summary>
    ///     Is this attribute marked as OPTIONAL?
    /// </summary>
    /// <returns></returns>
    public bool IsOptional { get; }

    public override string ToString()
    {
        return generator.AttributeDataString(this);
    }

    public string ToStepString(bool isDerivedInChild)
    {
        return generator.AttributeStepString(this, isDerivedInChild);
    }
}

/// <summary>
///     FunctionData stores information about functions.
/// </summary>
public class FunctionData
{
    public FunctionData(string name, TypeReference returnType, List<ParameterData> parameterData)
    {
        Name = name;
        Parameters = parameterData;
        ReturnType = returnType;
    }

    public string Name { get; set; }

    public List<ParameterData> Parameters { get; }

    public TypeReference ReturnType { get; }
}

/// <summary>
///     A TypeData object stores data about IFC types.
/// </summary>
public abstract class TypeData
{
    protected ILanguageGenerator generator;

    public TypeData(string name, ILanguageGenerator generator)
    {
        this.generator = generator;
        Name = name;
    }

    public string Name { get; set; }
}

/// <summary>
///     Base class for types which store a collection of values such as IFC SELECT and ENUM types.
/// </summary>
public abstract class CollectionTypeData : TypeData
{
    public CollectionTypeData(string name, ILanguageGenerator generator, IEnumerable<string> values) : base(name,
        generator)
    {
        Values = values;
    }

    /// <summary>
    ///     For a TypeData which wraps a Select or an Enum, the Values
    ///     collection will contain the items that are enumerated or selected.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<string> Values { get; }
}

/// <summary>
///     A WrapperType object stores data about IFC TYPEs.
/// </summary>
public class WrapperType : TypeData
{
    public WrapperType(string name, string wrappedType, ILanguageGenerator generator, bool isCollectionType, int rank) :
        base(name, generator)
    {
        IsCollectionType = isCollectionType;
        Rank = rank;
        WrappedType = wrappedType;
    }

    public bool IsCollectionType { get; }

    /// <summary>
    ///     For a TypeData which wraps a collection, the rank is the depth of
    ///     the collection. Ex: A collection with Rank=1 will be a List<List<object>>.
    /// </summary>
    /// <returns></returns>
    public int Rank { get; }

    /// <summary>
    ///     In the case of a simple type, the WrappedType
    ///     will be the name of type which is wrapped in an IfcType.
    /// </summary>
    /// <returns></returns>
    public string WrappedType { get; }

    public override string ToString()
    {
        return generator.SimpleTypeString(this);
    }
}

/// <summary>
///     A CollectionTypeData object stores information about IFC ENUM types.
/// </summary>
public class EnumType : CollectionTypeData
{
    public EnumType(string name, ILanguageGenerator generator, IEnumerable<string> values) : base(name, generator,
        values)
    {
    }

    public override string ToString()
    {
        return generator.EnumTypeString(this);
    }
}

/// <summary>
///     A SelectType object stores information about IFC SELECT types.
/// </summary>
public class SelectType : CollectionTypeData
{
    public SelectType(string name, ILanguageGenerator generator, IEnumerable<string> values) : base(name, generator,
        values)
    {
    }

    public override string ToString()
    {
        return generator.SelectTypeString(this);
    }
}

/// <summary>
///     An Entity object stores information about IFC ENTITY types.
/// </summary>
public class Entity : TypeData
{
    public Entity(string name, ILanguageGenerator generator) : base(name, generator)
    {
        Name = name;
        Supers = new List<Entity>();
        Subs = new List<Entity>();
        Attributes = new List<AttributeData>();
    }

    /// <summary>
    ///     The super types.
    /// </summary>
    public List<Entity> Supers { get; set; }

    /// <summary>
    ///     The inherited types.
    /// </summary>
    public List<Entity> Subs { get; set; }

    /// <summary>
    ///     The attributes.
    /// </summary>
    public List<AttributeData> Attributes { get; set; }

    /// <summary>
    ///     Is the Entity abstract?
    /// </summary>
    public bool IsAbstract { get; set; }

    /// <summary>
    ///     Return all parents to this type all the way to the root.
    /// </summary>
    /// <returns></returns>
    internal IEnumerable<Entity> Parents()
    {
        var parents = new List<Entity>();
        parents.AddRange(Subs);

        foreach (var s in Subs) parents.AddRange(s.Parents());

        return parents;
    }

    internal IEnumerable<Entity> ParentsAndSelf()
    {
        var parents = new List<Entity>();
        parents.Add(this);

        parents.AddRange(Subs);

        foreach (var s in Subs) parents.AddRange(s.Parents());

        return parents;
    }

    /// <summary>
    ///     Determine whether this is the provided type or a sub-type of the provided type.
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public bool IsTypeOrSubtypeOfEntity(string typeName)
    {
        if (Name == typeName) return true;

        foreach (var s in Subs)
        {
            var found = s.IsTypeOrSubtypeOfEntity(typeName);
            if (found) return true;
        }

        return false;
    }

    public string Properties(Dictionary<string, SelectType> selectData)
    {
        var attrs = Attributes;
        if (!attrs.Any()) return string.Empty;

        var propBuilder = new StringBuilder();
        foreach (var a in attrs)
        {
            var prop = a.ToString();
            if (!string.IsNullOrEmpty(prop)) propBuilder.AppendLine(prop);
        }

        return propBuilder.ToString();
    }

    public string StepProperties()
    {
        // Build a set of step properties for all parent classes and this class.
        var attrs = ParentsAndSelf().Reverse().SelectMany(t => t.Attributes).Where(a => !a.IsInverse && !a.IsDerived);

        var derAttrs = ParentsAndSelf().Reverse().SelectMany(t => t.Attributes)
            .Where(a => !a.IsInverse && a.IsDerived && a.HidesParentAttributeOfSameName);

        if (!attrs.Any()) return string.Empty;

        var propBuilder = new StringBuilder();
        foreach (var a in attrs)
        {
            // Attributes which are hidden by a derived attribute
            // of the same name in a child need to be written to 
            // STEP as *.
            var isDerivedInChild = false;
            if (derAttrs.Any(d => d.Name == a.Name)) isDerivedInChild = true;

            var prop = a.ToStepString(isDerivedInChild);
            if (!string.IsNullOrEmpty(prop)) propBuilder.AppendLine(prop);
        }

        return propBuilder.ToString();
    }

    public override string ToString()
    {
        return generator.EntityString(this);
    }
}