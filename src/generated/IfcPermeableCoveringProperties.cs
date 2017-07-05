/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcPermeableCoveringProperties : IfcPreDefinedPropertySet 
	{
		public IfcPermeableCoveringProperties(IfcShapeAspect shapeAspectStyle,
				IfcPermeableCoveringOperationEnum operationType,
				Boolean operationTypeSpecified,
				IfcWindowPanelPositionEnum panelPosition,
				Boolean panelPositionSpecified,
				Double frameDepth,
				Boolean frameDepthSpecified,
				Double frameThickness,
				Boolean frameThicknessSpecified) : base()
		{
			this.ShapeAspectStyle = shapeAspectStyle;
			this.OperationType = operationType;
			this.OperationTypeSpecified = operationTypeSpecified;
			this.PanelPosition = panelPosition;
			this.PanelPositionSpecified = panelPositionSpecified;
			this.FrameDepth = frameDepth;
			this.FrameDepthSpecified = frameDepthSpecified;
			this.FrameThickness = frameThickness;
			this.FrameThicknessSpecified = frameThicknessSpecified;
		}
	}
}