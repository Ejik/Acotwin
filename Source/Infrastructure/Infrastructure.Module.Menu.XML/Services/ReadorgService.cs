using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using ACOT.Infrastructure.Interface.Services;
using System.IO;
using ACOT.Infrastructure.Interface.BusinessEntities;
using Microsoft.Practices.CompositeUI.EventBroker;
using ACOT.Infrastructure.Interface.Constants;
using ACOT.Infrastructure.Interface;

namespace ACOT.Infrastructure.Module.Services
{
    // Объявление сервиса, опубликованного в модуле, в соответствии
    // с регистрацией его контракта
    [Service(typeof(IReadorgService))]
    public class ReadorgService : IReadorgService
    {               
        public ReadorgService()
        {           
        }

        private string GetOrgName(string dir)
        {
            string orgn = dir + "\\ORGNAME";
            if (System.IO.File.Exists(orgn))
            {
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(orgn);
                    string orgname = sr.ReadLine();
                    sr.Close();
                    return orgname;                   
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {                
                System.Windows.Forms.MessageBox.Show(ACOT.Infrastructure.Interface.Constants.ErrorNames.Err2);
                return null;                
            }
        }

        #region IReadorgService Members
                
        public List<ACOT.Infrastructure.Interface.BusinessEntities.Organization> orgsList(string dir)
        {
            // Строим список организаций
            DirectoryInfo _dir = new DirectoryInfo(dir);            
            List<Organization> list = new List<Organization>();
            foreach (FileInfo f in _dir.GetFiles("SPRAW.*"))
            {
                try
                {
                    Organization newOrg = new Organization(f.FullName);
                    list.Add(newOrg);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка: " + ex);
                }
            }
            return list;
        }
        

        Organization IReadorgService.GetOrg(string dir)
        {
            string orgname = this.GetOrgName(dir);
            if (orgname != null)
            {
                string filename = dir + "\\SPRAW." + orgname;
                return new ACOT.Infrastructure.Interface.BusinessEntities.Organization(filename);
            }
            else
                if (OnReadOrgShow != null)
                    OnReadOrgShow(this, new EventArgs<string>("N"));
            return null;
        }

        #endregion

        [EventPublication(EventTopicNames.ReadOrgShow, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnReadOrgShow;
    }
}
