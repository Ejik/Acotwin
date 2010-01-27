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
}
