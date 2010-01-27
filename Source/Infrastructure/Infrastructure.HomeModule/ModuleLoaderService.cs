using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.Configuration;
using ACOT.Infrastructure.Interface;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.CompositeUI.EventBroker;
using ACOT.Infrastructure.Interface.Constants;

namespace ACOT.Infrastructure.HomeModule
{
    public class ModuleLoaderService
    {

        IModuleLoaderService _moduleLoaderService;
        
        FileCatalogModuleEnumerator _modEnumerator;
        
        WorkItem _workItem;

        IModuleInfo[] _modules;

        [InjectionConstructor]
        public ModuleLoaderService
			(
                [ServiceDependency] IModuleLoaderService loader,
                [ServiceDependency] FileCatalogModuleEnumerator modEnumerator,
                [ServiceDependency] WorkItem workItem
			)
		{            
            _moduleLoaderService = loader;
            _modEnumerator = modEnumerator;            
            _workItem = workItem;

            _modules = _modEnumerator.EnumerateModules();
		}
        

        public void LoadModule(IModuleInfo module)
        {
            //_moduleLoaderService.ModuleLoaded += new EventHandler<DataEventArgs<LoadedModuleInfo>>(OnModuleLoaded);
            _moduleLoaderService.Load(_workItem, module);
        }

        #region Описание Событий
        [EventPublication(EventTopicNames.AboutDlgShow, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnAboutBoxShow;

        [EventPublication(EventTopicNames.CheckAddressViewShow, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnCheckAddressShow;

        [EventPublication(EventTopicNames.Exchange1Cv8Show, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnExchange1Cv8Show;

        [EventPublication(EventTopicNames.InfoViewShow, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnInfoViewModuleShow;

        [EventPublication(EventTopicNames.MenuTreeShow, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnMenuTreeShow;
        
        [EventPublication(EventTopicNames.SettingDlgShow, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnSettingsModuleShow;

        #endregion



        public void Load(System.Collections.ObjectModel.Collection<string> e)
        {
            string moduleName = e[0];
            foreach (IModuleInfo module in _modules)
            {
                if (module.AssemblyFile == moduleName)
                {
                    this.LoadModule(module);

                    switch (moduleName)
                    {
                        case ModuleNames.AboutModule : 
                            if (OnAboutBoxShow != null)
                                OnAboutBoxShow(this, new EventArgs<string>(""));
                            break;
                        
                        case ModuleNames.ChkAddrModule:
                            if (OnCheckAddressShow != null)
                                OnCheckAddressShow(this, new EventArgs<string>(e[1]));
                            break;

                        case ModuleNames.Exchange1CModule:
                            if (OnExchange1Cv8Show != null)
                                OnExchange1Cv8Show(this, new EventArgs<string>(""));
                            break;
                        
                        case ModuleNames.InfoViewModule :
                            if (OnInfoViewModuleShow != null)
                                OnInfoViewModuleShow(this, new EventArgs<string>(e[1]));
                            break;
                        
                        case ModuleNames.SettingsModule:
                            if(OnSettingsModuleShow != null)
                                OnSettingsModuleShow(this, new EventArgs<string>(""));
                                break;
                        
                        case ModuleNames.TreeModule:
                            if (OnMenuTreeShow != null)
                                OnMenuTreeShow(this, new EventArgs<string>(""));
                            break;                        
                    }
                }
            }
        }
     
    }
}
