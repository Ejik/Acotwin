
namespace ACOT.Infrastructure.Layout.Views
{
    partial class MenuTreeView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this._treeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // _treeView
            // 
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Node0";
            this._treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this._treeView.ShowNodeToolTips = true;
            this._treeView.Size = new System.Drawing.Size(188, 333);
            this._treeView.TabIndex = 0;
            this._treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeView_NodeMouseDoubleClick);
            this._treeView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._treeView_KeyPress);
            this._treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this._treeView_KeyDown);
            // 
            // MenuTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this._treeView);
            this.Name = "MenuTreeView";
            this.Size = new System.Drawing.Size(188, 333);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _treeView;

    }
}

