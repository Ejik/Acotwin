using System;
using System.Windows.Forms;
using Microsoft.Practices.ObjectBuilder;
using ACOT.Infrastructure.Interface.Constants;
using System.Drawing;
using Microsoft.Practices.CompositeUI.SmartParts;
using ACOT.Infrastructure.Interface;

namespace ACOT.InfoViewModule.Views
{
    public partial class LayoutView : UserControl, ISmartPartInfoProvider
    {
        private LayoutViewPresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ShellLayoutView"/> class.
        /// </summary>
        public LayoutView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Sets the presenter.
        /// </summary>
        /// <value>The presenter.</value>
        [CreateNew]
        public LayoutViewPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        #region ISmartPartInfoProvider Members

        ISmartPartInfo ISmartPartInfoProvider.GetSmartPartInfo(Type smartPartInfoType)
        {
            ISmartPartInfo spi;
            if (smartPartInfoType.IsAssignableFrom(typeof(ACOT.Infrastructure.Interface.WindowSmartPartInfo)))
            {
                WindowSmartPartInfo LayoutView = new WindowSmartPartInfo();
                LayoutView.Modal = false;
                LayoutView.MinimizeBox = true;
                LayoutView.MaximizeBox = true;
                LayoutView.ControlBox = true;
                LayoutView.Width = ACOT.InfoViewModule.Properties.Settings.Default.Size.Width;
                LayoutView.Height = ACOT.InfoViewModule.Properties.Settings.Default.Size.Height;
                LayoutView.Location = ACOT.InfoViewModule.Properties.Settings.Default.Location;

                LayoutView.Keys[WindowWorkspaceSetting.FormBorderStyle] = FormBorderStyle.Sizable;
                //LayoutView.Keys[WindowWorkspaceSetting.AcceptButton] = this._oKbtn;
                //LayoutView.Keys[WindowWorkspaceSetting.CancelButton] = this._cancelBtn;
                LayoutView.Keys[WindowWorkspaceSetting.KeyPreview] = true;
                LayoutView.Keys[WindowWorkspaceSetting.KeyDown] = new KeyEventHandler(InfoView_KeyDown);
                LayoutView.Keys[WindowWorkspaceSetting.FormShowIcon] = false;
                //LayoutView.Keys[WindowWorkspaceSetting.StartPosition] = FormStartPosition.CenterParent;
                //LayoutView.Keys[WindowWorkspaceSetting.AutoSize] = true;
                

                spi = LayoutView;
            }
            else
            {
                spi = Activator.CreateInstance(smartPartInfoType) as ISmartPartInfo;
            }

            //spi.Description = Properties.Resources.FindCustomerResultsViewDescription;
            spi.Title = "Просмотр информации о файлах";

            return spi;
        }

        #endregion

        public ToolStripComboBox FilterTool
        {
            get { return _filterTool; }
        }

        public DataGridView Grid
        {
            get { return _dataGrid; }
        }

        internal void SetFont(Font font)
        {
            this.Font = font;
            this._toolStrip.Font = font;
            this._filterTool.Font = font;
        }        

        private void _filterTool_SelectedIndexChanged(object sender, EventArgs e)
        {            
            switch (this._filterTool.SelectedIndex)
            {
                case 0: _presenter.FilterChange("*.exe"); break;
                case 1: _presenter.FilterChange("*.res"); break;
                case 2: _presenter.FilterChange("*.hlp"); break;
                case 3: _presenter.FilterChange("*."); break;
                case 4: _presenter.FilterChange("*.*"); break;
            }            
        }

        private void InfoView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                _presenter.OnCloseView();
        }

        private void _filterTool_TextUpdate(object sender, EventArgs e)
        {
            _presenter.FilterChange(this._filterTool.Text);
        }

    }

}
