/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcConversionBasedUnit : IfcNamedUnit 
	{
		public IfcConversionBasedUnit(IfcMeasureWithUnit conversionFactor,
				String name,
				IfcDimensionalExponents dimensions,
				IfcUnitEnum unitType,
				Boolean unitTypeSpecified) : base(dimensions,
				unitType,
				unitTypeSpecified)
		{
			this.ConversionFactor = conversionFactor;
			this.Name = name;
		}
	}
}