/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcLine : IfcCurve 
	{
		public IfcLine(IfcCartesianPoint pnt,
				IfcVector dir,
				IfcStyledItem styledByItem) : base(styledByItem)
		{
			this.Pnt = pnt;
			this.Dir = dir;
		}
	}
}