using System.IO;
using ACOT.Infrastructure.Interface.Services;
using Microsoft.Practices.CompositeUI;

namespace ACOT.InfoViewModule.Services
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
