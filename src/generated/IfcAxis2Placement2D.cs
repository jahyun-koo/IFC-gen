/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcAxis2Placement2D : IfcPlacement 
	{
		public IfcAxis2Placement2D(IfcDirection refDirection,
				IfcCartesianPoint location,
				IfcStyledItem styledByItem) : base(location,
				styledByItem)
		{
			this.RefDirection = refDirection;
		}
	}
}