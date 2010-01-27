using System;
using System.Collections.Generic;
using System.Text;

namespace ACOT.Infrastructure.Controls.TreeViewAdvanced
{
	public interface IToolTipProvider
	{
		string GetToolTip(TreeNodeAdv node);
	}
}
