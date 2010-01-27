using System;
using System.Collections.Generic;
using System.Text;

namespace ACOT.Infrastructure.Interface.Services
{
    /// <summary>
    /// Этот интерфейс определяет контракт для сервисов
    /// которые обеспечивают получение информации из файла MENU.DAT
    /// </summary>
    public interface IMenuImporterService
    {
        void ParseData();
    }
}
