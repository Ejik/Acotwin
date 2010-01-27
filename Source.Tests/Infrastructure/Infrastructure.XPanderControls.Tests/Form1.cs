using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Collections;
using ACOT.Infrastructure.Controls.XPanderControls;
using Panel=ACOT.Infrastructure.Controls.XPanderControls.Panel;

namespace Infrastructure.XPanderControls.Tests
{
    public partial class Form1 : Form
    {
        private PanelColors m_panelColors;
        private PanelStyle m_panelStyle;
        private ToolStripRenderer m_toolStripRenderer;
        private ACOT.Infrastructure.Controls.XPanderControls.ProfessionalColorTable m_professionalColorTable;
        private CaptionStyle m_captionStyle = CaptionStyle.Flat;
        private FormSettings m_formSettings;

        public Form1()
        {
            InitializeComponent();

            this.m_cboPanelStyle.SelectedValueChanged -= new System.EventHandler(this.PanelStylesSelectedValueChanged);
            this.m_cboPanelStyle.DataSource = Enum.GetValues(typeof(PanelStyle));
            this.m_cboPanelStyle.SelectedIndex = -1;
            this.m_cboPanelStyle.SelectedValueChanged += new System.EventHandler(this.PanelStylesSelectedValueChanged);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom("Infrastructure.Controls.dll");
            Type[] types = assembly.GetTypes();

            Type typeOfClass = typeof(PanelColors);
            foreach (Type type in types)
            {
                if ((type.IsClass == true) &&
                    (typeOfClass.IsAssignableFrom(type) == true))
                {
                    this.m_cboPanelColors.Items.Add(type);
                }
            }

            typeOfClass = typeof(System.Windows.Forms.ToolStripProfessionalRenderer);
            foreach (Type type in types)
            {
                if ((type.IsClass == true) &&
                    (typeOfClass.IsAssignableFrom(type) == true))
                {
                    this.m_cboToolStripRenderer.Items.Add(type);
                }
            }

            this.m_cboToolStripRenderer.Items.Add(typeof(ToolStripProfessionalRenderer));

            typeOfClass = typeof(System.Windows.Forms.ProfessionalColorTable);
            foreach (Type type in types)
            {
                if ((type.IsClass == true) &&
                    (typeOfClass.IsAssignableFrom(type) == true))
                {
                    this.m_cboProfessionalColorTable.Items.Add(type);
                }
            }

            //ToolStripManager.Renderer = new AquaRenderer(new ColorTableRed());
            //ToolStripManager.Renderer = new AquaRenderer();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.m_formSettings = new FormSettings();

            bool bPanel1Expand = this.m_formSettings.Panel1Expand;
            if (bPanel1Expand == false)
            {
                panel1.Width = this.m_formSettings.Panel1Bounds.Width;
                panel1.Expand = bPanel1Expand;
            }
            else
            {
                if (this.m_formSettings.Panel1Bounds != Rectangle.Empty)
                {
                    panel1.Width = this.m_formSettings.Panel1Bounds.Width;
                }
            }
            panel1.Visible = this.m_formSettings.Panel1Visible;

            bool bPanel2Expand = this.m_formSettings.Panel2Expand;
            if (bPanel2Expand == false)
            {
                panel2.Width = this.m_formSettings.Panel2Bounds.Width;
                panel2.Expand = bPanel2Expand;
            }
            else
            {
                if (this.m_formSettings.Panel2Bounds != Rectangle.Empty)
                {
                    panel2.Width = this.m_formSettings.Panel2Bounds.Width;
                }
            }
            panel2.Visible = this.m_formSettings.Panel2Visible;

            bool bPanel4Expand = this.m_formSettings.Panel4Expand;
            if (bPanel4Expand == false)
            {
                panel4.Height = this.m_formSettings.Panel4Bounds.Height;
                panel4.Expand = bPanel4Expand;
            }
            else
            {
                if (this.m_formSettings.Panel4Bounds != Rectangle.Empty)
                {
                    panel4.Height = this.m_formSettings.Panel4Bounds.Height;
                }
            }
            panel4.Visible = this.m_formSettings.Panel4Visible;

            bool bPanel5Expand = this.m_formSettings.Panel5Expand;
            if (bPanel5Expand == false)
            {
                panel5.Height = this.m_formSettings.Panel5Bounds.Height;
                panel5.Expand = bPanel5Expand;
            }
            else
            {
                if (this.m_formSettings.Panel5Bounds != Rectangle.Empty)
                {
                    panel5.Height = this.m_formSettings.Panel5Bounds.Height;
                }
            }
            panel5.Visible = this.m_formSettings.Panel5Visible;

            SetViewMenuItems();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_formSettings != null)
            {
                bool bExpandPanel1 = panel1.Expand;
                this.m_formSettings.Panel1Expand = panel1.Expand;
                this.m_formSettings.Panel1Visible = panel1.Visible;
                if (bExpandPanel1 == false)
                {
                    this.m_formSettings.Panel1Bounds = panel1.RestoreBounds;
                }
                else
                {
                    this.m_formSettings.Panel1Bounds = panel1.ClientRectangle;
                }

                bool bExpandPanel2 = panel2.Expand;
                this.m_formSettings.Panel2Expand = panel2.Expand;
                this.m_formSettings.Panel2Visible = panel2.Visible;
                if (bExpandPanel2 == false)
                {
                    this.m_formSettings.Panel2Bounds = panel2.RestoreBounds;
                }
                else
                {
                    this.m_formSettings.Panel2Bounds = panel2.ClientRectangle;
                }

                bool bExpandPanel4 = panel4.Expand;
                this.m_formSettings.Panel4Expand = panel4.Expand;
                this.m_formSettings.Panel4Visible = panel4.Visible;
                if (bExpandPanel4 == false)
                {
                    this.m_formSettings.Panel4Bounds = panel4.RestoreBounds;
                }
                else
                {
                    this.m_formSettings.Panel4Bounds = panel4.ClientRectangle;
                }

                bool bExpandPanel5 = panel5.Expand;
                this.m_formSettings.Panel5Expand = panel5.Expand;
                this.m_formSettings.Panel5Visible = panel5.Visible;
                if (bExpandPanel5 == false)
                {
                    this.m_formSettings.Panel5Bounds = panel5.RestoreBounds;
                }
                else
                {
                    this.m_formSettings.Panel5Bounds = panel5.ClientRectangle;
                }

                this.m_formSettings.Save();
            }
        }

        private void m_mnuFile_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelStylesSelectedValueChanged(object sender, EventArgs e)
        {
            if (this.m_cboPanelStyle.SelectedValue != null)
            {
                PanelStyle panelStyle = (PanelStyle)this.m_cboPanelStyle.SelectedValue;
                if (panelStyle != PanelStyle.None)
                {
                    this.m_panelStyle = panelStyle;
                    if (this.m_panelColors == null)
                    {
                        PanelSettingsManager.SetPanelProperties(
                            this.Controls,
                            this.m_panelStyle);
                    }
                    else
                    {
                        PanelSettingsManager.SetPanelProperties(
                            this.Controls,
                            this.m_panelStyle,
                            this.m_panelColors);
                    }
                }
            }
        }

        private void PanelColorsSelectedValueChanged(object sender, EventArgs e)
        {
            Type type = this.m_cboPanelColors.SelectedItem as Type;
            PanelColors panelColors = Activator.CreateInstance(type) as PanelColors;
            if (panelColors != null)
            {
                this.m_panelColors = panelColors;
                PanelSettingsManager.SetPanelProperties(
                    this.Controls,
                    this.m_panelStyle,
                    this.m_panelColors);
            }
            if (this.m_panelColors != null)
            {
                this.m_btnXPanderUseSystemColors.Enabled = true;
            }
        }

        private void m_cboToolStripRenderer_SelectedValueChanged(object sender, EventArgs e)
        {
            Type type = m_cboToolStripRenderer.SelectedItem as Type;
            ToolStripProfessionalRenderer toolStripProfessionalRenderer = null;
            if (this.m_professionalColorTable != null)
            {
                toolStripProfessionalRenderer = Activator.CreateInstance(type, new object[] { this.m_professionalColorTable }) as ToolStripProfessionalRenderer;
            }
            else
            {
                toolStripProfessionalRenderer = Activator.CreateInstance(type) as ToolStripProfessionalRenderer;
            }
            if (toolStripProfessionalRenderer != null)
            {
                if (toolStripProfessionalRenderer.Equals(this.m_toolStripRenderer) == false)
                {
                    this.m_toolStripRenderer = toolStripProfessionalRenderer;
                    ToolStripManager.Renderer = this.m_toolStripRenderer;
                }
            }
        }

        private void m_cboProfessionalColorTable_SelectedValueChanged(object sender, EventArgs e)
        {
            Type type = m_cboProfessionalColorTable.SelectedItem as Type;
            ACOT.Infrastructure.Controls.XPanderControls.ProfessionalColorTable professionalColorTable = Activator.CreateInstance(type) as ACOT.Infrastructure.Controls.XPanderControls.ProfessionalColorTable;
            if (professionalColorTable != null)
            {
                if (this.m_toolStripRenderer == null)
                {
                    this.m_professionalColorTable = professionalColorTable;
                    this.m_toolStripRenderer = new ToolStripProfessionalRenderer(this.m_professionalColorTable);
                    ToolStripManager.Renderer = this.m_toolStripRenderer;
                }
                else
                {
                    if (professionalColorTable.Equals(this.m_professionalColorTable) == false)
                    {
                        this.m_professionalColorTable = professionalColorTable;
                        this.m_toolStripRenderer = Activator.CreateInstance(this.m_toolStripRenderer.GetType(), new object[] { professionalColorTable }) as ToolStripProfessionalRenderer;
                        ToolStripManager.Renderer = this.m_toolStripRenderer;
                    }
                }
            }
            if (this.m_professionalColorTable != null)
            {
                this.m_btnToolStripUseSystemColors.Enabled = true;
            }
        }

        private void ButtonUseSystemColorsClick(object sender, EventArgs e)
        {
            if (this.m_professionalColorTable != null)
            {
                this.m_professionalColorTable.UseSystemColors = !this.m_professionalColorTable.UseSystemColors;
                if (this.m_toolStripRenderer != null)
                {
                    this.m_toolStripRenderer = Activator.CreateInstance(this.m_toolStripRenderer.GetType(), new object[] { this.m_professionalColorTable }) as ToolStripProfessionalRenderer;
                    ToolStripManager.Renderer = this.m_toolStripRenderer;
                }
            }
        }

        private void ButtonXPanderUseSystemColorsClick(object sender, EventArgs e)
        {
            if (this.m_panelColors != null)
            {
                this.m_panelColors.UseSystemColors = !this.m_panelColors.UseSystemColors;
                PanelSettingsManager.SetPanelProperties(
                    this.Controls,
                    this.m_panelStyle,
                    this.m_panelColors);
            }
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            splitter1.Visible = panel1.Visible;
            SetViewMenuItems();
        }

        private void panel2_VisibleChanged(object sender, EventArgs e)
        {
            splitter2.Visible = panel2.Visible;
            SetViewMenuItems();
        }

        private void panel4_VisibleChanged(object sender, EventArgs e)
        {
            splitter3.Visible = panel4.Visible;
            SetViewMenuItems();
        }

        private void panel5_VisibleChanged(object sender, EventArgs e)
        {
            splitter4.Visible = panel5.Visible;
            SetViewMenuItems();
        }

        private void PanelCloseClick(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.Visible = false;
                SetViewMenuItems();
            }
        }
        private void SetViewMenuItems()
        {
            this.m_mnuView.DropDownItems.Clear();
            ArrayList basePanels = PanelSettingsManager.FindPanels(true, this.Controls);
            foreach (BasePanel basePanel in basePanels)
            {
                Panel panel = basePanel as Panel;
                if ((panel != null) && ((panel.Dock != DockStyle.Fill) || (panel.Dock != DockStyle.None)) && (panel.ShowCloseIcon == true))
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = panel.Text;
                    menuItem.Image = panel.Image;
                    menuItem.Tag = panel;
                    menuItem.Click += new EventHandler(ViewMenuItemsClick);
                    if (panel.Visible == true)
                    {
                        menuItem.Checked = true;
                    }
                    this.m_mnuView.DropDownItems.Add(menuItem);
                }
            }
        }

        private void ViewMenuItemsClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                Panel panel = menuItem.Tag as Panel;
                if (panel != null)
                {
                    panel.Visible = !panel.Visible;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (xPanderPanel8 != null)
            {
                xPanderPanelList2.Expand(xPanderPanel8);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            xPanderPanel3.Visible = !xPanderPanel3.Visible;
        }

        private void XPanderPanelListControlRemoved(object sender, ControlEventArgs e)
        {
            XPanderPanelList xpanderPanelList = sender as XPanderPanelList;
            XPanderPanel xpanderPanel = e.Control as XPanderPanel;
            if ((xpanderPanel != null) && (xpanderPanelList != null))
            {
                MessageBox.Show(string.Format("'{0}' removed from '{1}'", xpanderPanel.Text,xpanderPanelList.Name));
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            XPanderPanel xpanderPanel = new XPanderPanel();
            xpanderPanel.Text = "new XPanderPanel";
            xpanderPanel.CaptionHeight = xPanderPanelList1.CaptionHeight;
            xPanderPanelList1.XPanderPanels.Add(xpanderPanel);
            if (this.m_panelColors != null)
            {
                xpanderPanel.SetPanelProperties(this.m_panelColors);
            }
        }

        private void m_btnChangeCaptionStyle_Click(object sender, EventArgs e)
        {
            if (this.m_captionStyle == CaptionStyle.Flat)
            {
                this.m_captionStyle = CaptionStyle.Normal;
            }
            else
            {
                this.m_captionStyle = CaptionStyle.Flat;
            }
            xPanderPanelList1.CaptionStyle = this.m_captionStyle;
        }
    }

	public class FormSettings : ApplicationSettingsBase
	{
		[UserScopedSetting()]
		[DefaultSettingValue("true")]
		public bool Panel1Expand
		{
			get { return ((bool)this["Panel1Expand"]); }
			set { this["Panel1Expand"] = (bool)value; }
		}
        [UserScopedSetting()]
        [DefaultSettingValue("true")]
        public bool Panel1Visible
        {
            get { return ((bool)this["Panel1Visible"]); }
            set { this["Panel1Visible"] = (bool)value; }
        }
		[UserScopedSetting()]
		public Rectangle Panel1Bounds
		{
			get
			{
				if (this["Panel1Bounds"] == null)
				{
					return Rectangle.Empty;
				}
				else
				{
					return ((Rectangle)this["Panel1Bounds"]);
				}
			}
			set { this["Panel1Bounds"] = (Rectangle)value; }
		}
		[UserScopedSetting()]
		[DefaultSettingValue("true")]
		public bool Panel2Expand
		{
			get { return ((bool)this["Panel2Expand"]); }
			set { this["Panel2Expand"] = (bool)value; }
		}
        [UserScopedSetting()]
        [DefaultSettingValue("true")]
        public bool Panel2Visible
        {
            get { return ((bool)this["Panel2Visible"]); }
            set { this["Panel2Visible"] = (bool)value; }
        }
		[UserScopedSetting()]
		public Rectangle Panel2Bounds
		{
			get
			{
				if (this["Panel2Bounds"] == null)
				{
					return Rectangle.Empty;
				}
				else
				{
					return ((Rectangle)this["Panel2Bounds"]);
				}
			}
			set { this["Panel2Bounds"] = (Rectangle)value; }
		}
		[UserScopedSetting()]
		[DefaultSettingValue("true")]
		public bool Panel4Expand
		{
			get { return ((bool)this["Panel4Expand"]); }
			set { this["Panel4Expand"] = (bool)value; }
		}
        [UserScopedSetting()]
        [DefaultSettingValue("true")]
        public bool Panel4Visible
        {
            get { return ((bool)this["Panel4Visible"]); }
            set { this["Panel4Visible"] = (bool)value; }
        }
		[UserScopedSetting()]
		public Rectangle Panel4Bounds
		{
			get
			{
				if (this["Panel4Bounds"] == null)
				{
					return Rectangle.Empty;
				}
				else
				{
					return ((Rectangle)this["Panel4Bounds"]);
				}
			}
			set { this["Panel4Bounds"] = (Rectangle)value; }
		}
		[UserScopedSetting()]
		[DefaultSettingValue("true")]
		public bool Panel5Expand
		{
			get { return ((bool)this["Panel5Expand"]); }
			set { this["Panel5Expand"] = (bool)value; }
		}
        [UserScopedSetting()]
        [DefaultSettingValue("true")]
        public bool Panel5Visible
        {
            get { return ((bool)this["Panel5Visible"]); }
            set { this["Panel5Visible"] = (bool)value; }
        }
		[UserScopedSetting()]
		public Rectangle Panel5Bounds
		{
			get
			{
				if (this["Panel5Bounds"] == null)
				{
					return Rectangle.Empty;
				}
				else
				{
					return ((Rectangle)this["Panel5Bounds"]);
				}
			}
			set { this["Panel5Bounds"] = (Rectangle)value; }
		}
	}
}