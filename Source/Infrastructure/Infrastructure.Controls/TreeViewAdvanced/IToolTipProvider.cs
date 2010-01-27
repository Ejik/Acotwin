using System;
using System.Collections.Generic;
using System.Text;
using ACOT.Infrastructure.Controls.TreeViewAdvanced.NodeControls;
using ACOT.Infrastructure.Controls.TreeViewAdvanced.NodeControls;
using ACOT.Infrastructure.Controls.TreeViewAdvanced.NodeControls;

namespace ACOT.Infrastructure.Controls.TreeViewAdvanced
{
	public interface IToolTipProvider
	{
		string GetToolTip(TreeNodeAdv node, NodeControl nodeControl);
	}
}
