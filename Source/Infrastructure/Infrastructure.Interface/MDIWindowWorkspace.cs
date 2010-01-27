using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.WinForms;

namespace ACOT.Infrastructure.Interface
{
    public class MDIWindowWorkspace : WindowWorkspaceExtended 
    {
        public Form ParentMdiForm { get; set; }

        public MDIWindowWorkspace(Form parentForm)
        {
            this.ParentMdiForm = parentForm;
        }

        protected override void OnShow(Control smartPart, Microsoft.Practices.CompositeUI.WinForms.WindowSmartPartInfo smartPartInfo)
        {
            base.OnShow(smartPart, smartPartInfo);
            Form mdiChild = this.GetOrCreateForm(smartPart);
            mdiChild.MdiParent = ParentMdiForm;

            this.SetWindowProperties(mdiChild, smartPartInfo);
            mdiChild.Show();
            this.SetWindowLocation(mdiChild, smartPartInfo);
            mdiChild.BringToFront();
        }
    }
}
