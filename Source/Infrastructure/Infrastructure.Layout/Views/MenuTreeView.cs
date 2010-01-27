using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using System.Windows.Forms;
using ACOT.Infrastructure.Interface.BusinessEntities;
using Microsoft.Practices.CompositeUI;

namespace ACOT.Infrastructure.Layout.Views
{
    [SmartPart]
    public partial class MenuTreeView : UserControl
    {
        private MenuTreeViewPresenter _presenter;

        public MenuTreeView()
        {
            InitializeComponent();            
        }

        [CreateNew]
        public MenuTreeViewPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public TreeView Tree
        {
            get { return this._treeView; }
        }


        /*public void FillTree(MenuStrip menuStrip)
        {
            _presenter.FillTree(menuStrip);
        }
         */

        public void FillTree(MenuStrip menuStrip)
        {
            Tree.Nodes.Clear();
            foreach (ToolStripMenuItemElement item in menuStrip.Items)
            {
                TreeNode node = new TreeNode();
                node.Tag = item.ID;
                node.Text = item.Text.Replace("&", "");
                node.ToolTipText = item.ToolTipText;
                
                this.Tree.Nodes.Add(node);                

                if (item.DropDownItems.Count != 0)
                    ChildWalk(item, node);
            }
        }

        private void ChildWalk(ToolStripMenuItemElement _rootitem, TreeNode _node)
        {

            foreach (ToolStripMenuItemElement item in _rootitem.DropDownItems)
            {
                TreeNode node = new TreeNode();
                node.Tag = item.ID;
                node.Text = item.Text.Replace("&", ""); ;
                node.ToolTipText = item.ToolTipText;

                _node.Nodes.Add(node);
                if (item.DropDownItems.Count != 0)
                    ChildWalk(item, node);
            }
        }

        private void _treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.Tree.SelectedNode != null)
                _presenter.TreeClick((string)this.Tree.SelectedNode.Tag);                                        
        }
      
        private void _treeView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Tree.SelectedNode != null)
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Enter : _presenter.TreeClick((string)this.Tree.SelectedNode.Tag); break;
                    
                }
            }
        }

        private void _treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Tree.SelectedNode != null)
                switch (e.KeyCode)
                {
                    case Keys.F3: _presenter.ViewLST((string)this.Tree.SelectedNode.Tag); break;
                }
        }                
    }
}
