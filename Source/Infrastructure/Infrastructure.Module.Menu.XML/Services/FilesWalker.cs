using System;
using System.Collections.Generic;
using System.Text;
using ACOT.Infrastructure.Interface;
using ACOT.Infrastructure.Interface.BusinessEntities;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using System.IO;
using ACOT.Infrastructure.Interface.Services;

namespace ACOT.Infrastructure.Module.Services
{
    [Service(typeof(IFilesWalker))]        
    public class FilesWalker : IFilesWalker
    {        
        [ServiceDependency]
        public WorkItem WorkItem { get; set; }        
               
        #region IFilesWalker Members        
        public FileInfo[] GetFilesList(string filter)
        {
            IContextService context = WorkItem.Services.Get<IContextService>();        
            string path = context.startupDir;
            DirectoryInfo dir = new DirectoryInfo(path);
            return dir.GetFiles(filter);
        }

        #endregion     
    }     
}
