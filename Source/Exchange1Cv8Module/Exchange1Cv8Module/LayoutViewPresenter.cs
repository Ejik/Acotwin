//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by the "Add Foundational Module" recipe.
//
// The LayoutView usercontrol defines a layout decoupled from the shell. 
// It provides a left and right workspace, menu bar, tool bar and status bar.
// These ui elements are added as extension sites.
//
// For more information see:
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.scsf.2006jun/SCSF/html/03-290-Automation%20Add%20Foundational%20Module.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System.Threading;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using ACOT.Infrastructure.Interface;
using ACOT.Exchange1Cv8Module.Constants;
using System;


namespace ACOT.Exchange1Cv8Module
{
    public class LayoutViewPresenter : Presenter<LayoutView>
    {
        public override void OnViewReady()
        {
            base.OnViewReady();               
        }

        internal void CloseLayoutView()
        {
            this.WorkItem.Items.Remove(View);
            if (this.View is IDisposable) ((IDisposable)this.View).Dispose();

            base.CloseView();

            this.WorkItem.RootWorkItem.Items.Remove(this);
        }        
    }
}