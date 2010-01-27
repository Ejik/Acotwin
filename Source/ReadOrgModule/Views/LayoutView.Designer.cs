
//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by the "Add View" recipe.
//
// For more information see: 
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.scsf.2006jun/SCSF/html/03-030-Model%20View%20Presenter%20%20MVP%20.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

namespace ACOT.ReadOrgModule
{
    partial class LayoutView
    {
        /// <summary>
        /// The presenter used by this view.
        /// </summary>
        private ACOT.ReadOrgModule.LayoutViewPresenter _presenter = null;

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
            if (disposing)
            {
                if (_presenter != null)
                    _presenter.Dispose();

                if (components != null)
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.infoProvider = new Microsoft.Practices.CompositeUI.SmartParts.SmartPartInfoProvider();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteOrgBtn = new System.Windows.Forms.Button();
            this.orgsGrid = new System.Windows.Forms.DataGridView();
            this.����������� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.����� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.��� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.���������� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oKBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orgsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.deleteOrgBtn);
            this.GroupBox1.Controls.Add(this.orgsGrid);
            this.GroupBox1.Location = new System.Drawing.Point(8, 5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(495, 232);
            this.GroupBox1.TabIndex = 16;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "����������";
            // 
            // deleteOrgBtn
            // 
            this.deleteOrgBtn.Location = new System.Drawing.Point(6, 197);
            this.deleteOrgBtn.Name = "deleteOrgBtn";
            this.deleteOrgBtn.Size = new System.Drawing.Size(128, 20);
            this.deleteOrgBtn.TabIndex = 2;
            this.deleteOrgBtn.Text = "������� �����������";
            this.deleteOrgBtn.UseVisualStyleBackColor = true;
            this.deleteOrgBtn.Click += new System.EventHandler(this.deleteOrgBtn_Click);
            // 
            // orgsGrid
            // 
            this.orgsGrid.AllowUserToAddRows = false;
            this.orgsGrid.AllowUserToDeleteRows = false;
            this.orgsGrid.AllowUserToResizeColumns = false;
            this.orgsGrid.AllowUserToResizeRows = false;
            this.orgsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orgsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orgsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.orgsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.�����������,
            this.�����,
            this.���,
            this.����������,
            this.ID});
            this.orgsGrid.Location = new System.Drawing.Point(6, 19);
            this.orgsGrid.MultiSelect = false;
            this.orgsGrid.Name = "orgsGrid";
            this.orgsGrid.ReadOnly = true;
            this.orgsGrid.RowHeadersVisible = false;
            this.orgsGrid.RowTemplate.Height = 25;
            this.orgsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orgsGrid.Size = new System.Drawing.Size(482, 172);
            this.orgsGrid.TabIndex = 1;
            this.orgsGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.orgsGrid_CellMouseDoubleClick);
            this.orgsGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orgsGrid_KeyDown);
            // 
            // �����������
            // 
            this.�����������.HeaderText = "�����������";
            this.�����������.Name = "�����������";
            this.�����������.ReadOnly = true;
            // 
            // �����
            // 
            this.�����.FillWeight = 50F;
            this.�����.HeaderText = "�����";
            this.�����.Name = "�����";
            this.�����.ReadOnly = true;
            // 
            // ���
            // 
            this.���.FillWeight = 50F;
            this.���.HeaderText = "���";
            this.���.Name = "���";
            this.���.ReadOnly = true;
            // 
            // ����������
            // 
            this.����������.FillWeight = 50F;
            this.����������.HeaderText = "����������";
            this.����������.Name = "����������";
            this.����������.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Visible = false;
            // 
            // oKBtn
            // 
            this.oKBtn.Location = new System.Drawing.Point(347, 243);
            this.oKBtn.Name = "oKBtn";
            this.oKBtn.Size = new System.Drawing.Size(75, 23);
            this.oKBtn.TabIndex = 3;
            this.oKBtn.Text = "OK";
            this.oKBtn.UseVisualStyleBackColor = true;
            this.oKBtn.Click += new System.EventHandler(this.oKBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(428, 243);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "������";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ReadOrgLayoutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.oKBtn);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Name = "ReadOrgLayoutView";
            this.Size = new System.Drawing.Size(507, 273);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orgsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Practices.CompositeUI.SmartParts.SmartPartInfoProvider infoProvider;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button deleteOrgBtn;
        private System.Windows.Forms.DataGridView orgsGrid;
        private System.Windows.Forms.Button oKBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn �����������;
        private System.Windows.Forms.DataGridViewTextBoxColumn �����;
        private System.Windows.Forms.DataGridViewTextBoxColumn ���;
        private System.Windows.Forms.DataGridViewTextBoxColumn ����������;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;       
    }
}

