using System;
using System.Collections.Generic;
using System.Text;
using ACOT.Infrastructure.Controls.TreeViewAdvanced.NodeControls;
using ACOT.Infrastructure.Controls.TreeViewAdvanced.NodeControls;
using ACOT.Infrastructure.Controls.TreeViewAdvanced.NodeControls;
using System.Drawing;

namespace ACOT.Infrastructure.Controls.TreeViewAdvanced
{
	public struct NodeControlInfo
	{
		public static readonly NodeControlInfo Empty = new NodeControlInfo(null, Rectangle.Empty, null);

		private NodeControl _control;
		public NodeControl Control
		{
			get { return _control; }
		}

		private Rectangle _bounds;
		public Rectangle Bounds
		{
			get { return _bounds; }
		}

		private TreeNodeAdv _node;
		public TreeNodeAdv Node
		{
			get { return _node; }
		}

		public NodeControlInfo(NodeControl control, Rectangle bounds, TreeNodeAdv node)
		{
			_control = control;
			_bounds = bounds;
			_node = node;
		}
	}
}
