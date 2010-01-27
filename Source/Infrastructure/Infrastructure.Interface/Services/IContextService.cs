using System;
using System.Collections.Generic;
using System.Text;
using ACOT.Infrastructure.Interface.BusinessEntities;

namespace ACOT.Infrastructure.Interface.Services
{
    /// <summary>
    /// Интерфейс для сервисе контекста. 
    /// </summary>
    public interface IContextService
    {        
        Organization organization { get; set; }

        string startupDir { get; set; }

        string version { get; set; }

        string shellCaption { get; }

        string orgname { get; }

        string desktop { get; set; }

        bool menuTreeVisible { get; set; }

        System.Drawing.Font Font { get; set; }

        ACOT.Infrastructure.Interface.Data.MenuData menuData { get; set; }

        System.Diagnostics.Stopwatch sw { get; set; }

        void Dispose();

        void Reload();

        void Save();

        void RefreshOrganization();
    }
}
