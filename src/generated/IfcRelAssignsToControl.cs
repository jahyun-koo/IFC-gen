/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcRelAssignsToControl : IfcRelAssigns 
	{
		public IfcRelAssignsToControl(IfcControl relatingControl,
				IfcRelAssignsRelatedObjects relatedObjects,
				IfcObjectTypeEnum relatedObjectsType,
				Boolean relatedObjectsTypeSpecified) : base(relatedObjects,
				relatedObjectsType,
				relatedObjectsTypeSpecified)
		{
			this.RelatingControl = relatingControl;
		}
	}
}