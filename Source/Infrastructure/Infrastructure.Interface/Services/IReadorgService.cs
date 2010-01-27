using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ACOT.Infrastructure.Interface.Services
{
    /// <summary>
    /// Этот интерфейс определяет контракт для сервисов
    /// которые обеспечивают получение информации об организации.
    /// </summary>
    public interface IReadorgService
    {
        ACOT.Infrastructure.Interface.BusinessEntities.Organization GetOrg(string dir);
        
        List<ACOT.Infrastructure.Interface.BusinessEntities.Organization> orgsList(string dir);
    }
}
