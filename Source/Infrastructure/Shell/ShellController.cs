using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ACOT.Infrastructure.Interface.BusinessEntities;
using ACOT.Infrastructure.Interface.Constants;
using ACOT.Infrastructure.Interface.Services;
using ACOT.Infrastructure.Shell.Properties;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using ACOT.Infrastructure.Interface;
using Microsoft.Practices.ObjectBuilder;

namespace ACOT.Infrastructure.Shell
{
    public class ShellController
    {
        public ShellForm View;

        private WorkItem _workItem;
        private IContextService _context;

        [InjectionConstructor]
        public ShellController(WorkItem workItem)
        {
            _workItem = workItem;
            
            //m_mdiWorkspace = new MdiWorkspace(this);
        }

        public void SetVisibility(bool param)
        {
            // Установим видимость левой панели в соответствии с установками
            View.TreePanel.Visible = param;
            Settings.Default.LeftPanelVisible = param;

            _context = _workItem.RootWorkItem.Services.Get<IContextService>();
            _context.menuTreeVisible = param;
        }

        #region Обработчики событий

        [EventSubscription(EventTopicNames.AcotExit, ThreadOption.UserInterface)]
        public void OnFileExit(object sender, EventArgs e)
        {
            // Сохраняем настройки
            Settings.Default.Save();

            // Закрываем  приложение
            View.Close();
            Environment.Exit(0);
        }

        [EventSubscription(EventTopicNames.StatusUpdate, ThreadOption.UserInterface)]
        public void StatusUpdateHandler(object sender, EventArgs<string> e)
        {
            if (e.Data != null)
                View.StatusLabel.Text = e.Data;
        }

        [EventSubscription(EventTopicNames.OrganizationChange, ThreadOption.UserInterface)]
        public void OrganizationChangeHandler(object sender, EventArgs<ACOT.Infrastructure.Interface.BusinessEntities.Organization> e)
        {
            if (e.Data != null)
            {
               View.Text = (e.Data as Organization).ToString();
            }
        }

        [EventSubscription(EventTopicNames.FontChange, ThreadOption.UserInterface)]
        public void FontChangeHandler(object sender, EventArgs<Font> e)
        {
            if (e.Data != null)
            {
                Font font = e.Data;
                View.Font = font;
                View.MenuStrip.Font = font;
            }
        }
       
        [EventSubscription(EventTopicNames.DesktopChange, ThreadOption.UserInterface)]
        public void DesktopChangeHandler(object sender, EventArgs<string> e)
        {
            if (e.Data != null)
            {
                if (e.Data == "")
                    View.BackgroundImage = null;
                else
                    View.BackgroundImage = new Bitmap(e.Data);
            }
        }

        [EventSubscription(EventTopicNames.MenuTreeVisibleChange, ThreadOption.UserInterface)]
        public void LeftPanelVisiblyChange(object sender, EventArgs<bool> e)
        {
            SetVisibility(e.Data);
        }

#endregion  
    }
}