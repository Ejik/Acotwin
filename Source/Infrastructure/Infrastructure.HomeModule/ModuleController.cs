using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI.Configuration;
using ACOT.Infrastructure.Interface;
using Microsoft.Practices.CompositeUI.EventBroker;
using ACOT.Infrastructure.Interface.Constants;

namespace ACOT.Infrastructure.HomeModule
{
    public class ModuleController : WorkItemController
    {
        public override void Run()
        {
            AddServices();
            ExtendMenu();
            ExtendToolStrip();
            AddViews();            
        }

        private void AddServices()
        {

            FileCatalogModuleEnumerator modEnumerator = new FileCatalogModuleEnumerator("ProfileCatalogOndemand.xml");
            WorkItem.Services.Add<FileCatalogModuleEnumerator>(modEnumerator);
            
            IModuleLoaderService loader = WorkItem.Services.Get<IModuleLoaderService>();            
            WorkItem.Services.Add<ModuleLoaderService>(new ModuleLoaderService(loader, modEnumerator, WorkItem));
        }

        private void ExtendMenu()
        {
            
        }

        private void AddMenuItem(ToolStripMenuItem parent, string text, string command, Keys shortcutKeys)
        {
            
        }

        private void ExtendToolStrip()
        {
        }

        private void AddViews()
        {
        }
        
        [EventSubscription(EventTopicNames.ModuleLoad, Thread = ThreadOption.UserInterface)]
        public void ModuleLoadHandler(object sender, EventArgs<System.Collections.ObjectModel.Collection<string>> e)
        {          
            ModuleLoaderService loader = WorkItem.Services.Get<ModuleLoaderService>();
            loader.Load(e.Data);
        }     
    }    
}
