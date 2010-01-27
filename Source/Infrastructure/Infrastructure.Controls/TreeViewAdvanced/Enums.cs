using System;
using System.Collections.Generic;
using System.Text;

namespace ACOT.Infrastructure.Controls.TreeViewAdvanced
{
	public enum DrawSelectionMode
	{
		None, Active, Inactive, FullRowSelect
	}

	public enum TreeSelectionMode
	{
		Single, Multi, MultiSameParent
	}

	public enum NodePosition
	{
		Inside, Before, After
	}

	public enum VerticalAlignment
	{
		Top, Bottom, Center
	}

	public enum IncrementalSearchMode
	{
		None, Standard, Continuous
	}

	[Flags]
    public enum GridLineStyle
    {
		None = 0, 
		Horizontal = 1, 
		Vertical = 2, 
		HorizontalAndVertical = 3
    }
}
