using System;
using System.Collections.Generic;
using System.Text;
using ACOT.Infrastructure.Interface.Data;
using Microsoft.Practices.CompositeUI;
using ACOT.Infrastructure.Interface.Services;
using System.IO;

namespace ACOT.Infrastructure.Interface.BusinessEntities
{
    public class Organization
    {

        private string title = "";      // Название организации
        private string ext = "";        // Расширение
        private int curMonth = 1;	    // Текущий месяц		
        private int curYear = 2000;		// Текущий год

        private bool _forceRefreshData;        
        private string localPath;

        public OrganizationDataSet dataset = new OrganizationDataSet();

        #region Структура файла ADRES
        private struct Address
        {
            public int tna;
            public char[] fio;
            public char[] kodstran;
            public char[] kodreg;
            public char[] index;
            public char[] gorod;
            public char[] n_punkt;
            public char[] raion;
            public char[] ulica;
            public char[] dom;
            public char[] korp;
            public char[] kvart;
            public char[] tail;

            public Address(int _tna, char[] _fio, char[] _kodstran, char[] _kodreg,
                char[] _index, char[] _gorod, char[] _n_punkt, char[] _raion, char[] _ulica,
                char[] _dom, char[] _korp, char[] _kvart, char[] _tail)
            {
                tna = _tna;
                fio = new char[44];
                kodstran= new char[3];
                kodreg = new char[2];
                index = new char[6];
                gorod = new char[40];
                n_punkt= new char[40];
                raion = new char[25];
                ulica = new char[40];
                dom = new char[7];
                korp = new char[2];
                kvart = new char[5];
                tail = new char[8379];

            }
        }
        #endregion

        public Organization(string sprawn)
        {
            this.localPath = Path.GetDirectoryName(sprawn);
            this.ext = System.IO.Path.GetExtension(sprawn).Trim('.');

            this.dataset.OrgInfoTable.AddOrgInfoTableRow("1", this.title, this.ext, this.curMonth, this.curYear);

            this.ForceRefreshData = true;

        }

        public override string ToString()
        {
            return "Организация " + this.title + "(" + this.ext + "),   текущий месяц - " +
                MonthNames.names[this.curMonth] + "   " +
                    this.curYear.ToString() + " - ACOT для windows";
        }

        public bool ForceRefreshData
        {
            get { return this._forceRefreshData; }
            set
            {
                this._forceRefreshData = value;
                if (value)
                    OnForceRefreshData();
            }
        }

        private void OnForceRefreshData()
        {
            try
            {
                if (this.ext != "")
                {
                    byte[] buf = new byte[2000];
                    //char[] buf2 = new char[2000];

                    //StreamReader sr = new StreamReader(this.localPath + "\\SPRAW." + this.ext, Encoding.GetEncoding(866));
                    //sr.ReadBlock(buf2, 0, 2000);
                    //this.curMonth = (int)buf2[84];

                    //*this.curYear = (Int32)buf[86];
                    //sr.Close();


                    System.IO.FileStream fsr = new System.IO.FileStream(this.localPath + "\\SPRAW." + this.ext, System.IO.FileMode.Open);
                    //sr = new StreamReader(startupDir + spraw, Encoding.GetEncoding(866));
                    fsr.Read(buf, 0, 2000);
                    
                    // Текущий месяц
                    this.curMonth = (int)buf[84];
                    if (((int)this.curMonth < 1) || ((int)this.curMonth > 12))
                        this.curMonth = 1;

                    
                    // Текущий год
                    //string s = Microsoft.VisualBasic.Conversion.Hex(buf[87]) + Microsoft.VisualBasic.Conversion.Hex(buf[86]);
                    //string s = buf[87].ToString() + buf[86].ToString();
                    this.curYear = BitConverter.ToInt16(buf, 86); // Convert.ToInt32(s, 16);
                    if (((int)(this.curYear) < 1997) || ((int)(this.curYear) > 2100))
                        this.curYear = 2000;

                    byte[] b = new byte[20];
                    for (int i = 0; i < 20; i++)
                        b[i] = buf[180 + i];

                    byte[] res = Encoding.Convert(Encoding.GetEncoding(866), Encoding.UTF8, b);
                    this.title = Encoding.UTF8.GetString(res);

                    fsr.Close();

                    this.ForceRefreshData = false;


                    OrganizationDataSet.OrgInfoTableRow row = (OrganizationDataSet.OrgInfoTableRow)dataset.OrgInfoTable.Rows[0];
                    row.title = this.title;
                    row.ext = this.ext;
                    row.curmonth = this.curMonth;
                    row.curyear = this.curYear;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Сбой при чтении первой записи.", "SPRAW");
            }
        }

        #region Информация об организации

        public string getTitle()
        {
            if (System.IO.File.Exists(this.localPath + "\\SPRAW." + this.ext))
            {
                if (!ForceRefreshData)
                    ForceRefreshData = true;
                OrganizationDataSet.OrgInfoTableRow row = (OrganizationDataSet.OrgInfoTableRow)dataset.OrgInfoTable.Rows[0];
                return row.title;
            }
            else
                System.Windows.Forms.MessageBox.Show("Сбой при открытии SPRAW", "SPRAW");
            return "";
        }

        public string getExt() 
        {
            OrganizationDataSet.OrgInfoTableRow row = (OrganizationDataSet.OrgInfoTableRow)dataset.OrgInfoTable.Rows[0];
            return row.ext;
        }

        public int getMonth() 
        {
            if (!ForceRefreshData) 
                ForceRefreshData = true;
            
            OrganizationDataSet.OrgInfoTableRow row = (OrganizationDataSet.OrgInfoTableRow)dataset.OrgInfoTable.Rows[0];
            return row.curmonth;
        }

        public string getMonth(int m)
        {
            return MonthNames.names[m];
        }

        public string getMonthName()
        {

            return MonthNames.names[this.getMonth()];
        }

        public int GetYear()
        {
            if (!ForceRefreshData)
                ForceRefreshData = true;
            OrganizationDataSet.OrgInfoTableRow row = (OrganizationDataSet.OrgInfoTableRow)dataset.OrgInfoTable.Rows[0];
            return row.curyear;
        }

        
        #endregion

        public void FillAdresTable()
        {
            string fADRES = this.localPath + "\\" + "ADRES." + ext;
            if (File.Exists(fADRES))
            {

                StreamReader sr = new StreamReader(fADRES, Encoding.GetEncoding(866));
                char[] buffer = new char[6400];
                while (!sr.EndOfStream)
                {
                    sr.ReadBlock(buffer, 0, 6400);

                    Address sAdres = new Address();
                    //sAdres = &buffer;

                    OrganizationDataSet.AdresTableRow newrow = this.dataset.AdresTable.NewAdresTableRow();
                    int tna = (int)buffer[1];
                    tna = tna << 4;
                    tna &= (int)buffer[0];
                    newrow.tna = tna;
                    this.dataset.AdresTable.AddAdresTableRow(newrow);
                }
                sr.Close();


                


            }
            else
                System.Windows.Forms.MessageBox.Show("Сбой при открытии ADRES", "ADRES");

        }
    }
}
