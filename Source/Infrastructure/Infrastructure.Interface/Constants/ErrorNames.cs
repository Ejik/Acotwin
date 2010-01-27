using System;
using System.Collections.Generic;
using System.Text;

namespace ACOT.Infrastructure.Interface.Constants
{
    public class ErrorNames
    {
        /// <summary>
        /// Ошибка 1: Ошибка чтения файла menu.dat
        /// </summary>
        public const string Err1 = "Ошибка 1: Ошибка чтения файла MENU.DAT";

        /// <summary>
        /// Ошибка 2: Ошибка чтения файла orgname
        /// </summary>
        public const string Err2 = "Ошибка 2:  Нет ни одного подходящего файла SPRAW";
        
        /// <summary>
        /// Ошибка 3: Файл STARTER.exe в каталоге ИБ не обнаружен
        /// </summary>
        public const string Err3 = "Ошибка 3: Файл STARTER.EXE в каталоге информационной базы не найден";

        /// <summary>
        /// Ошибка 4: Каталог ИБ не обнаружен
        /// </summary>
        public const string Err4 = "Ошибка 4: Каталог ИБ не обнаружен.";
    }
}
