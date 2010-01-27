using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using ACOT.Infrastructure.Interface;
using ACOT.Infrastructure.Interface.Constants;
using ACOT.Infrastructure.Interface.Services;
using Microsoft.Practices.CompositeUI.EventBroker;


namespace ACOT.InfoViewModule.Views
{

    public class LayoutViewPresenter : Presenter<LayoutView>
    {
        protected override void OnViewSet()
        {
            IContextService context = WorkItem.RootWorkItem.Services.Get<IContextService>();
            View.SetFont(context.Font);            
        }

        public void OnCloseView()
        {
            View.ParentForm.Close();
            //View.ParentForm.Close();            
            base.CloseView();
            //this.WorkItem.Items.Remove(View);
            //if (this.View is IDisposable)
            //    ((IDisposable)this.View).Dispose();

            //this.WorkItem.RootWorkItem.Items.Remove(this);            
        }
        
        [EventSubscription(EventTopicNames.FontChange, ThreadOption.UserInterface)]
        public void FontChangeHandler(object sender, EventArgs<Font> e)
        {
            if (e.Data != null)            
                View.SetFont(e.Data);            
        }

        
        public void FilterChange(string filter)
        {
            IContextService context = WorkItem.RootWorkItem.Services.Get<IContextService>();
            if (filter == "*.")
                filter += context.orgname;
            View.Grid.Rows.Clear();

            IFilesWalker walker = WorkItem.Services.Get<IFilesWalker>();
            FileInfo[] info = walker.GetFilesList(filter);
            
            foreach (FileInfo inf in info)
            {                
                FileVersionInfo ver = FileVersionInfo.GetVersionInfo(inf.FullName);
                DateTime dt = inf.LastWriteTime;
                object[] obj = new object[] {inf.Name, inf.Length, 
                                   dt.Date,
                                   dt.TimeOfDay, 
                                   ver.FileVersion};
                View.Grid.Rows.Add(obj);                
            }  
        }
 
    }
}
