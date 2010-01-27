using System;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using ACOT.Infrastructure.Interface;
using ACOT.Infrastructure.Interface.Constants;

namespace ACOT.Infrastructure.Layout.Views
{
    public class MenuTreeViewPresenter : Presenter<MenuTreeView>
    {        
        protected override void OnViewSet()
        {
            base.OnViewSet();

            //WorkItem.UIExtensionSites.RegisterSite(UIExtensionSiteNames.MainMenuTreeView, View.Tree);
        }

        [EventPublication(EventTopicNames.MainMenuClick, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnMainMenuClick;

        [EventPublication(EventTopicNames.MainMenuKeyDown, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnMainMenuKeyDown;

        internal void TreeClick(string p)
        {
            if (OnMainMenuClick != null)
                OnMainMenuClick(this, new EventArgs<string>(p));
        }

        internal void ViewLST(string p)
        {
            if (OnMainMenuKeyDown != null)
                OnMainMenuKeyDown(this, new EventArgs<string>(p));
        }
    }
}

