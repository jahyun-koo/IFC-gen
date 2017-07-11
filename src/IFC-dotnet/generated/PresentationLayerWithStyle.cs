/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/ifcpresentationlayerwithstyle.htm
	/// </summary>
	internal  partial class PresentationLayerWithStyle : PresentationLayerAssignment 
	{
		public PresentationLayerWithStyleLayerStyles LayerStyles {get;set;}

		public Logical LayerOn {get;set;}

		public Logical LayerFrozen {get;set;}

		public Logical LayerBlocked {get;set;}

		public PresentationLayerWithStyle(PresentationLayerWithStyleLayerStyles layerStyles,
				Logical layerOn,
				Logical layerFrozen,
				Logical layerBlocked,
				PresentationLayerAssignmentAssignedItems assignedItems,
				String name,
				String description,
				String identifier) : base(assignedItems,
				name,
				description,
				identifier)
		{
			this.LayerStyles = layerStyles;
			this.LayerOn = layerOn;
			this.LayerFrozen = layerFrozen;
			this.LayerBlocked = layerBlocked;
		}
	}
}