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
    // ќбъ€вление сервиса, опубликованного в модуле, в соответствии
    // с регистрацией его контракта
    [Service(typeof(IReadorgService))]
    public class ReadorgService : IReadorgService
    {               
        public ReadorgService()
        {           
        }

        private string GetOrgName(string dir)
        {
            // »щем все подход€щие файлы SPRAW (по крайней мере, у
            //них должна быть перва€ запись, откуда читаетс€ название 
            // организации и за какой год и мес€ц данные)

            string orgn = dir + "\\ORGNAME";
            if (File.Exists(orgn))
            {
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(orgn);
                    int i = 0;
                    string orgname = "";
                    char[] buf = new char[1];
                    while (!sr.EndOfStream && i <= 2)
                    {                        
                        sr.Read(buf, 0, 1);
                        orgname += buf[0].ToString();
                        i++;
                    }                    
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
                List<Organization> list = orgsList(dir);
                if (list != null)
                {
                    if (list.Count == 1)
                    {
                        Organization org = (Organization)list[0];
                        SetORGNAME(dir, org.getExt());
                        return org.getExt();
                    }
                    if (list.Count == 0)
                    {
                        System.Windows.Forms.MessageBox.Show(ErrorNames.Err2);
                        return null;
                    }

                    if (list.Count > 1)
                    {
                        if (OnReadOrgShow != null)
                            OnReadOrgShow(this, new EventArgs<string>("N"));
                        return null;
                    }
                }
                
                return null;
                //if (OnReadOrgShow != null)
                //    OnReadOrgShow(this, new EventArgs<string>("N"));               
            }
        }

        private void SetORGNAME(string dir, string text)
        {
            StreamWriter sw = new StreamWriter(dir + "\\ORGNAME");
            sw.Write(text);
            //sw.WriteLine(text);
            sw.Close();
        }

        #region IReadorgService Members
                
        public List<Organization> orgsList(string dir)
        {
            // —троим список организаций
            DirectoryInfo _dir = new DirectoryInfo(dir);
            if (Directory.Exists(dir))
            {
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
                        System.Windows.Forms.MessageBox.Show("ќшибка: " + ex);
                    }
                }
                return list;
            }
            return null;
        }        

        public Organization GetOrg(string dir)
        {
            string orgname = this.GetOrgName(dir);
            if (orgname != null)
            {
                string filename = dir + "\\SPRAW." + orgname;
                return new Organization(filename);
            }            
            
            // выход из ј—ќ“
            return null;
        }

        #endregion

        [EventPublication(EventTopicNames.ReadOrgShow, PublicationScope.Global)]
        public event EventHandler<EventArgs<string>> OnReadOrgShow;
    }
}
