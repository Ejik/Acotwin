using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACOT.Infrastructure.Interface.Constants;
using ACOT.Infrastructure.Interface.Data;
using ACOT.Infrastructure.Interface.Services;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace ACOT.Infrastructure.Module.Services
{
    [Service(typeof(IMenuImporterService))]
    public class MenuImporter : IMenuImporterService
    {
        private IContextService context;
        private WorkItem _workitem;

        [InjectionConstructor]
        public MenuImporter([ServiceDependency] WorkItem workitem)
        {
            this._workitem = workitem;           
        }

        #region IMenuImporterService Members
        public void ParseData()
        {
            this.context = _workitem.RootWorkItem.Services.Get<IContextService>();
            string menu = context.startupDir + "\\menu.dat";
            MenuData md = new MenuData();
            context.menuData = md;
            if (System.IO.File.Exists(menu))
            {                                   
                    using (StreamReader sr = new StreamReader(menu, System.Text.Encoding.GetEncoding(866)))
                    {
                        string s = "";
                        string id = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            try
                            {
                                id = ExtractMenuNumber(s);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при разборе файла MENU.DAT");
                            }
                            if (id != "     ")
                            {

                                MenuData._mainMenuRow newRow = md._mainMenu.New_mainMenuRow();
                                newRow.ID = id;
                                newRow.NAME = ExtractMenuHeader(s);

                                Collection<string[]> cmds = ExtractCommands(s);
                                if (cmds != null)
                                {           
                                    int i = 1;
                                    foreach(string[] cmd in cmds)
                                    {
                                        switch (i)
                                        {
                                            case 1: newRow.CMD1 = cmd[0]; break;
                                            case 2: newRow.CMD2 = cmd[0]; break;
                                            case 3: newRow.CMD3 = cmd[0]; break;
                                            case 4: newRow.CMD4 = cmd[0]; break;
                                            case 5: newRow.CMD5 = cmd[0]; break;
                                        }
                                        i++;
                                    }                                    
                                }                                
                                
                                newRow.CMDNAME = AppropriateCommandName(newRow) ;
                                if (newRow.CMDNAME == string.Empty)
                                    newRow.SetCMD1Null();

                                //menuItem.ToolTipText = rootNode.Attributes["Подсказка"].Value;
                                md._mainMenu.Add_mainMenuRow(newRow);
                            }
                        }
                    }                                        
                    // Пpосмотp ДАТ и РАЗМЕРОВ программных файлов в варианте WINDOWS
                    //AddNewParentToolStripMenuElement(, UIExtensionSiteNames.InfoViewMenuItem, "", "Пpосмотp ДАТ и РАЗМЕРОВ программных файлов в варианте WINDOWS", UIExtensionSiteNames.DifferentMenuItem);

                    //AddNewToolStripMenuElement("&Пpосмотp ДАТ и РАЗМЕРОВ программных файлов в варианте WINDOWS", UIExtensionSiteNames.InfoViewMenuItem, "", "Пpосмотp ДАТ и РАЗМЕРОВ программных файлов в варианте WINDOWS", UIExtensionSiteNames.DifferentMenuItem);
                    //AddNewToolStripMenuElement("Пpосмотp ДАТ и РАЗМЕРОВ программ EXE", "00791", CommandNames.InfoViewExeShow, "", UIExtensionSiteNames.InfoViewMenuItem);
                    //AddNewToolStripMenuElement("Пpосмотp ДАТ и РАЗМЕРОВ программ RES", "00792", CommandNames.InfoViewResShow, "", UIExtensionSiteNames.InfoViewMenuItem);
                    //AddNewToolStripMenuElement("Пpосмотp ДАТ и РАЗМЕРОВ программ HLP", "00793", CommandNames.InfoViewHlpShow, "", UIExtensionSiteNames.InfoViewMenuItem);
                    //AddNewToolStripMenuElement("Просмотр ДАТ и РАЗМЕРОВ наборов текущей организации", "00794", CommandNames.InfoViewCurShow, "", UIExtensionSiteNames.InfoViewMenuItem);
                    //AddNewToolStripMenuElement("Просмотр ДАТ и РАЗМЕРОВ *.???", "00795", CommandNames.InfoViewAllShow, "", UIExtensionSiteNames.InfoViewMenuItem);

                    // Установки          
                    //AddNewParentToolStripMenuElement("&УСТАНОВКИ", "00009", "", "Установки программы", UIExtensionSiteNames.MainMenu);
                    AddNewToolStripMenuElement("&УСТАНОВКИ", "000099", "", "Установки программы", UIExtensionSiteNames.MainMenu);

                    // Экран приветствия
                    //AddNewToolStripMenuElement("&Экран приветствия", "00091", CommandNames.SplashShow, "Показать заставку", UIExtensionSiteNames.SettingsMenu);

                    // Обмен данными с 1С
                    //AddNewToolStripMenuElement("&Обмен с 1С", "00091", CommandNames.Exchange1CDlgShow, "Обмен с 1С", UIExtensionSiteNames.SettingsMenu);
                    
                    // Настройки
                    AddNewToolStripMenuElement("&Настройка", "000992", CommandNames.SettingsShow, "Настройки программы", UIExtensionSiteNames.SettingsMenu);
                    // О программе
                    AddNewToolStripMenuElement("&О программе...", "000993", CommandNames.AboutBoxShow, "О программе", UIExtensionSiteNames.SettingsMenu);

                }
                else
                    MessageBox.Show(ErrorNames.Err1, "ACOT");
      
            // Выход
            AddNewToolStripMenuElement("&ВЫХОД", CommandNames.AcotExit, CommandNames.AcotExit, "Выход из АСОТ", UIExtensionSiteNames.MainMenu);


            context.menuData.AcceptChanges();
            //context.menuData.WriteXml("menu.xml");
        }
        #endregion

        private Collection<string[]> ExtractCommands(string s)
        {
            Collection<string[]> res = new Collection<string[]>();
            Collection<string> buf = new Collection<string>();
            Regex re = new Regex(@"{.*?}");

            foreach (Match m in re.Matches(s))
                buf.Add(m.Value);

            // Удаляем  строку с названием 
            buf.RemoveAt(0);

            if (buf.Count != 0)
            {
                foreach (string s1 in buf)
                {
                    string[] r = new string[1];
                    r[0] = s1.Remove(0, 1);
                    r[0] = r[0].Remove(r[0].Length - 1, 1);
                    res.Add(r);
                }
                return res;
            }
            else
                return null;
        }

        private string ExtractMenuHeader(string s)
        {
            string buf = "";
            int i = 6;
            while (s[i] != '}')
            {
                buf += s[i];
                i++;
            }
            buf = buf.Replace("_", "&");
            string ret = "";
            foreach (char k in buf)
                if (((int)k != 9474) && ((int)k != 16))
                    ret += k;

            return ret;
        }

        private string ExtractMenuNumber(string s)
        {
            if (s != "")
            {
                string buf = "";
                for (int i = 0; i < 5; i++)
                    buf += s[i];
                return buf;
            }
            return "     ";
        }

        private string AppropriateCommandName(MenuData._mainMenuRow row)
        {
            if (!row.IsCMD1Null())
            {
                if (row.NAME.Contains(Constants.CommandNames.СведенияОбОрганизации))
                    return "00111";
                if (row.NAME.Contains(Constants.CommandNames.ПереходНаСледМесяцВклСдвиг))
                    return "00072";
                if (row.NAME.Contains(Constants.CommandNames.СменаОрганизации))
                    return "00014";
                if (row.NAME.Contains(Constants.CommandNames.ПроизводственныыйКалендарьВинд))
                    return "01132";
                if (row.NAME.Contains(Constants.CommandNames.ПечатьPRNLST))
                    return "00471";
                if (row.NAME.Contains(Constants.CommandNames.ПечатьPRNCARD))
                    return "00472";
                if (row.NAME.Contains(Constants.CommandNames.ПреобразованиеФайловTXT2DBF))
                    return "00473";
                if (row.NAME.Contains(Constants.CommandNames.ПоказатьCправку))
                    return "00811";
                if (row.NAME.Contains(Constants.CommandNames.ПечатьКнигДокументации))
                    return "00815";
                if (row.NAME.Contains(Constants.CommandNames.УниверсальныйОбменXML))
                    return "00091";
                return "defaultClick";
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// Метод доавляет новый родительский элемент в главное меню программы
        /// </summary>
        /// <param name="_text">Заголовок</param>
        /// <param name="_id">Код</param>
        /// <param name="_commandName">Имя команды - вероятно не используется</param>
        /// <param name="_toolTipText">Подсказка</param>
        /// <param name="_UIExtensionSite">Место а меню, где будет помещен родительский элемент</param>
        private void AddNewParentToolStripMenuElement(string _text, string _id, string _commandName, string _toolTipText, string _UIExtensionSite)
        {
            //ToolStripMenuItemElement newElem = new ToolStripMenuItemElement(_text);
            //MenuData._mainMenuRow newRow = context.menuData._mainMenu.New_mainMenuRow();
            //newRow.ID = _id;
            //newRow.NAME = _text;
            //newRow.CMDNAME = _commandName;
            //newRow.TIP = _toolTipText;
            //context.menuData._mainMenu.Add_mainMenuRow(newRow);
            //if (!WorkItem.RootWorkItem.UIExtensionSites.Contains(_UIExtensionSite))
            //{
            //    ToolStripMenuItemElement parentElem = new ToolStripMenuItemElement(_UIExtensionSite);
            //    parentElem.ID = _UIExtensionSite;
            //    WorkItem.RootWorkItem.UIExtensionSites[UIExtensionSiteNames.MainMenu].Add(parentElem);
            //    WorkItem.RootWorkItem.UIExtensionSites.RegisterSite(parentElem.ID, parentElem.DropDownItems);
            //}
            //WorkItem.RootWorkItem.UIExtensionSites[_UIExtensionSite].Add(newElem);
            //WorkItem.RootWorkItem.UIExtensionSites.RegisterSite(newElem.ID, newElem.DropDownItems);           
        }

        /// <summary>
        /// Метод доавляет новый элемент в главное меню программы
        /// </summary>
        /// <param name="_text">Заголовок</param>
        /// <param name="_id">Код</param>
        /// <param name="_commandName">Имя команды</param>
        /// <param name="_toolTipText">Подсказка</param>
        /// <param name="_UIExtensionSite">Место а меню, где будет помещен элемент</param>
        private void AddNewToolStripMenuElement(string _text, string _id, string _commandName, string _toolTipText, string _UIExtensionSite)
        {
            //ToolStripMenuItemElement newElem = new ToolStripMenuItemElement(_text);
            //newElem.ID = _id;
            //newElem.CommandName = _commandName;
            //newElem.ToolTipText = _toolTipText;
            //WorkItem.RootWorkItem.UIExtensionSites[_UIExtensionSite].Add(newElem);
            //WorkItem.Commands[_commandName].AddInvoker(newElem, "Click");

            MenuData._mainMenuRow newRow = context.menuData._mainMenu.New_mainMenuRow();
            newRow.ID = _id;
            newRow.NAME = _text;
            newRow.CMDNAME = _commandName;
            newRow.TIP = _toolTipText;
            newRow.CMD1 = "";
            context.menuData._mainMenu.Add_mainMenuRow(newRow);
        }
    }
}
