using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI.Commands;
using ACOT.Infrastructure.Interface;
using Microsoft.Practices.CompositeUI.EventBroker;
using ACOT.Infrastructure.Interface.BusinessEntities;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using ACOT.Infrastructure.Module.Properties;
using ACOT.Infrastructure.Interface.Services;
using ACOT.Infrastructure.Interface.Constants;
using System.IO;

namespace ACOT.Infrastructure.Module.Services
{
    [Service(typeof(IContextService))]
    public class Context : IContextService
    {
        #region Private members

        private WorkItem _workItem;

        private Organization _organization;
        
        private string _startupDir;

        private System.Drawing.Font _Font;

        private string _desktop;

        private bool _showMenuTree;
        
        #endregion

        [InjectionConstructor]
        public Context(WorkItem workitem)
        {
            _workItem = workitem;
            Reload();
        }

        public void Reload()
        {
            //this._startupDir = System.Windows.Forms.Application.StartupPath + "\\";            
            string[] mmVer = System.Windows.Forms.Application.ProductVersion.Split('.');
            this.version = "ACOT версия " + mmVer[0] + "." + mmVer[1] + " сборка " + mmVer[2];

            Settings.Default.Reload();
            startupDir = Settings.Default.StartupDir;
            Font = Settings.Default.Font;
            desktop = Settings.Default.desktop;
            menuTreeVisible = Settings.Default.menuTreeVisible;
        }

        public void RefreshOrganization()
        {
            IReadorgService readorg = _workItem.RootWorkItem.Services.Get<IReadorgService>();
            Organization org = readorg.GetOrg(this.startupDir);
            if (org != null)
                organization = org;
            else
            {
                Dispose();
                if (OnAcotExit != null)
                    OnAcotExit(this, new EventArgs<string>(""));
            }
        }

        public void Save()
        {
            Settings.Default.Version = version;
            Settings.Default.StartupDir = _startupDir;
            Settings.Default.desktop = desktop;
            Settings.Default.Font = Font;
            Settings.Default.menuTreeVisible = menuTreeVisible;
            Settings.Default.Save();
        }

        #region IContextService Members

        public Organization organization
        {
            get { return _organization; }
            set
            {
                this._organization = value;
                this.OnOrganizationChangeHandler(this._organization);
            }
        }

        public string orgname
        {
            get { return this._organization.getExt(); }            
        }

        public string startupDir
        {
            get { return this._startupDir; }
            set
            {
                this._startupDir = value;
                this.OnAcotDirChange();
            }
        }

        public string version {get; set;}        

        public string shellCaption
        {
            get { return this._organization.ToString(); }
        }

        public System.Drawing.Font Font
        {
            get { return this._Font; }
            set
            {
                this._Font = value;
                this.onFontChangeHandler(this._Font);
            }
        }

        public string desktop
        {
            get { return this._desktop; }
            set
            {
                this._desktop = value;
                this.onDesktopChangeHandler(value);
            }
        }

        public bool menuTreeVisible
        {
            get { return this._showMenuTree; }
            set { this._showMenuTree = value; }
        }

        public ACOT.Infrastructure.Interface.Data.MenuData menuData { get; set; }

        public System.Diagnostics.Stopwatch sw { get; set; }
        
        #endregion

        #region Описания событий
        [EventPublication(EventTopicNames.FontChange, PublicationScope.Global)]
        public event EventHandler<EventArgs<System.Drawing.Font>> OnFontChange;

        [EventPublication(EventTopicNames.OrganizationChange, PublicationScope.Global)]
        public event EventHandler<EventArgs<Organization>> OnOrganizationChange;

        [EventPublication(EventTopicNames.DesktopChange, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnDesktopChange;

        [EventPublication(EventTopicNames.AcotExit, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnAcotExit;

        #endregion

        #region Обработчики событий

        public void OnOrganizationChangeHandler(Organization organization)
        {
            if (OnOrganizationChange != null)
                OnOrganizationChange(this, new EventArgs<Organization>(organization));
        }

        private void onFontChangeHandler(System.Drawing.Font font)
        {
            if (OnFontChange != null)
                OnFontChange(this, new EventArgs<System.Drawing.Font>(font));
        }

        private void onDesktopChangeHandler(string value)
        {
            if (OnDesktopChange != null)
                OnDesktopChange(this, new EventArgs<string>(value));
        }
       
        private void OnAcotDirChange()
        {
            //string startupDir = System.IO.Directory.GetCurrentDirectory();
            if (Directory.Exists(this._startupDir))
            {
                System.IO.Directory.SetCurrentDirectory(this._startupDir);
                this.RefreshOrganization();
            }
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Save();            
        }

        #endregion
    }
}
