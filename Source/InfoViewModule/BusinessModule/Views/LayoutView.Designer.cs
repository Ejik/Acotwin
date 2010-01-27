namespace ACOT.InfoViewModule.Views
{
    partial class LayoutView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dataGrid = new System.Windows.Forms.DataGridView();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this.Маска = new System.Windows.Forms.ToolStripLabel();
            this._filterTool = new System.Windows.Forms.ToolStripComboBox();
            this.FileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGrid)).BeginInit();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGrid
            // 
            this._dataGrid.AllowUserToAddRows = false;
            this._dataGrid.AllowUserToDeleteRows = false;
            this._dataGrid.AllowUserToResizeRows = false;
            this._dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileNameColumn,
            this.SizeColumn,
            this.DateColumn,
            this.TimeColumn,
            this.Version});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this._dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGrid.Location = new System.Drawing.Point(0, 25);
            this._dataGrid.Margin = new System.Windows.Forms.Padding(4);
            this._dataGrid.MultiSelect = false;
            this._dataGrid.Name = "_dataGrid";
            this._dataGrid.ReadOnly = true;
            this._dataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this._dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dataGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this._dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGrid.Size = new System.Drawing.Size(700, 475);
            this._dataGrid.TabIndex = 0;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Маска,
            this._filterTool});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(700, 25);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // Маска
            // 
            this.Маска.Name = "Маска";
            this.Маска.Size = new System.Drawing.Size(42, 22);
            this.Маска.Text = "Маска:";
            // 
            // _filterTool
            // 
            this._filterTool.Items.AddRange(new object[] {
            "Файлы EXE",
            "Файлы RES",
            "Файлы HLP",
            "Файлы текущей организации",
            "Все файлы"});
            this._filterTool.Name = "_filterTool";
            this._filterTool.Size = new System.Drawing.Size(200, 25);
            this._filterTool.SelectedIndexChanged += new System.EventHandler(this._filterTool_SelectedIndexChanged);
            this._filterTool.TextUpdate += new System.EventHandler(this._filterTool_TextUpdate);
            // 
            // FileNameColumn
            // 
            this.FileNameColumn.HeaderText = "Название";
            this.FileNameColumn.Name = "FileNameColumn";
            this.FileNameColumn.ReadOnly = true;
            // 
            // SizeColumn
            // 
            this.SizeColumn.HeaderText = "Размер";
            this.SizeColumn.Name = "SizeColumn";
            this.SizeColumn.ReadOnly = true;
            // 
            // DateColumn
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.DateColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateColumn.HeaderText = "Дата";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            // 
            // TimeColumn
            // 
            dataGridViewCellStyle3.Format = "t";
            dataGridViewCellStyle3.NullValue = null;
            this.TimeColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.TimeColumn.HeaderText = "Время";
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            // 
            // Version
            // 
            this.Version.HeaderText = "Версия";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // LayoutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this._dataGrid);
            this.Controls.Add(this._toolStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LayoutView";
            this.Size = new System.Drawing.Size(700, 500);
            ((System.ComponentModel.ISupportInitialize)(this._dataGrid)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGrid;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripComboBox _filterTool;
        private System.Windows.Forms.ToolStripLabel Маска;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;

    }
}
