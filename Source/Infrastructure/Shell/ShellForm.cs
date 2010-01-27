//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by this guidance package as part of the solution template
//
// The FormShell class represent the main form of your application.
// 
// For more information see: 
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.scsf.2006jun/SCSF/html/03-210-Creating%20a%20Smart%20Client%20Solution.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System.Windows.Forms;
using ACOT.Infrastructure.Interface.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI;
using System.Drawing;
using ACOT.Infrastructure.Interface;
using System;
using ACOT.Infrastructure.Interface.Services;
using ACOT.Infrastructure.Interface.BusinessEntities;
using System.IO;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;

namespace ACOT.Infrastructure.Shell
{
    /// <summary>
    /// Main application shell view.
    /// </summary>
    public partial class ShellForm : Form
    {
        private ShellController _controller;
       
       
        /// <summary>
        /// Default class initializer.
        /// </summary>
        public ShellForm()
        {
            InitializeComponent();
            _deckWorkspace.Name = WorkspaceNames.DeckWorkspace;
        }

        [CreateNew]
        public ShellController Controller
        {
            set 
            { 
                _controller = value;
                _controller.View = this;
            }
        }


        

        /// <summary>
        /// Gets the main menu strip.
        /// </summary>
        /// <value>The main menu strip.</value>
        internal MenuStrip MenuStrip
        {
            get { return _mainMenuStrip; }
        }

        /// <summary>
        /// Gets the main status strip.
        /// </summary>
        /// <value>The main status strip.</value>
        internal StatusStrip MainStatusStrip
        {
            get { return _mainStatusStrip; }
        }

        /// <summary>
        /// Gets the main toolbar strip.
        /// </summary>
        /// <value>The main toolbar strip.</value>
        internal ToolStrip MainToolbarStrip
        {
            get { return _mainToolStrip; }
        }

        /// <summary>
        /// ���������� ������ ���� ToolStripStatusLabel �������� ������.
        /// </summary>
        internal ToolStripStatusLabel StatusLabel
        {
            get { return _statusLabel; }
        }

        internal Controls.XPanderControls.Panel TreePanel
        {
            get { return _treePanel; }
        }

        internal Controls.XPanderControls.Splitter Splitter
        {
            get { return _splitter; }
        }

        private void _treePanel_CloseClick(object sender, EventArgs e)
        {
            _controller.SetVisibility(false);
        }
    }
}
