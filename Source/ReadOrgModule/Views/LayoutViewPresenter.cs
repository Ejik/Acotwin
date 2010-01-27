//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by the "Add View" recipe.
//
// A presenter calls methods of a view to update the information that the view displays. 
// The view exposes its methods through an interface definition, and the presenter contains
// a reference to the view interface. This allows you to test the presenter with different 
// implementations of a view (for example, a mock view).
//
// For more information see:
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.scsf.2006jun/SCSF/html/03-030-Model%20View%20Presenter%20%20MVP%20.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI;
using ACOT.Infrastructure.Interface;
using ACOT.Infrastructure.Interface.Services;
using Microsoft.Practices.CompositeUI.EventBroker;
using ACOT.Infrastructure.Interface.Constants;
using System.Windows.Forms;
using System.IO;
using ACOT.Infrastructure.Interface.BusinessEntities;
using System.Collections.Generic;
using System.Text;

namespace ACOT.ReadOrgModule
{
    public class LayoutViewPresenter : Presenter<LayoutView>
    {
        private List<Organization> orgsList;
        
        //private IContextService _context;

        //private IReadorgService _readorg;
                
        [ServiceDependency] 
        public IContextService Context { get; set;}
                               
        [ServiceDependency]
        public IReadorgService Readorg {get; set;}
        //{
        //    get { return _readorg; }
        //    set { _readorg = value; }
        //}

        /// <summary>
        /// This method is a placeholder that will be called by the view when it's been loaded <see cref="System.Winforms.Control.OnLoad"/>
        /// </summary>
        public override void OnViewReady()
        {
            base.OnViewReady();                        
            this.View.Font = Context.Font;
            this.updateView("");
        }
              
        /// <summary>
        /// Close the view
        /// </summary>
        public void OnCloseView()
        {
            base.CloseView();
        }

        public void OnCancel()
        {
            this.OnCloseView();            
        }

        public void OnOK(DataGridViewRow dataGridViewRow)
        {
            if (dataGridViewRow != null)
            {                
                StreamWriter w = new StreamWriter(Context.startupDir + "\\ORGNAME", false, Encoding.GetEncoding(866));
                w.Write(dataGridViewRow.Cells["����������"].Value);
                w.Close();

                Context.organization = dataGridViewRow.Cells["ID"].Value as Organization;                                
            }
            this.OnCloseView();
        }

        [EventSubscription(EventTopicNames.FontChange, ThreadOption.UserInterface)]
        public void FontChangeHandler(object sender, EventArgs<System.Drawing.Font> e)
        {
            if (e.Data != null)
            {
                View.SetFont(e.Data);
            }
        }
    
        internal void deleteSelectedOrg(DataGridViewRow dataGridViewRow)
        {
            if (MessageBox.Show("�� �������?", "ACOT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ext = (string)dataGridViewRow.Cells["����������"].Value;
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(this.Context.startupDir);
                foreach (FileInfo f in dir.GetFiles("*." + ext))
                    f.Delete();
                this.View.OrgsGrid.Rows.Remove(dataGridViewRow);
                this.View.EnableCtrlButtons(true, false, true);
            }
        }

        internal void updateView(string dir)
        {
            string startupDir;
            if (dir == "")            
                startupDir = Context.startupDir;
            else
                startupDir = dir;

            if (Directory.Exists(startupDir))
            {                                    
                orgsList = Readorg.orgsList(startupDir);
                View.OrgsGrid.Rows.Clear();
                if (orgsList.Count != 0)
                {
                    foreach (Organization org in orgsList)
                    {
                        int i = View.OrgsGrid.Rows.Add();
                        DataGridViewRow row = View.OrgsGrid.Rows[i];
                        row.Cells["�����������"].Value = org.getTitle();
                        row.Cells["�����"].Value = org.getMonthName();
                        row.Cells["���"].Value = org.GetYear();
                        row.Cells["����������"].Value = org.getExt();
                        row.Cells["ID"].Value = org;
                        if (Context.organization != null)
                            if (org.getExt() == Context.orgname)
                                this.View.OrgsGrid.CurrentCell = row.Cells[0];
                    }
                    
                    View.EnableCtrlButtons(true, true, true);
                }
                else
                    View.EnableCtrlButtons(false, true, false);
            }
        }
    }
}
