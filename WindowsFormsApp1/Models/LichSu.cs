using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class LichSu
    {
        private int id;
        public int pid
        {
            get { return id; }
            set { id = value; }
        }
        private Ghe ghe;
        public Ghe pghe
        {
            get { return ghe; }
            set { ghe = value; }
        }
        private KhachHang kh;
        public KhachHang pkh
        {
            get { return kh; }
            set { kh = value; }
        }
        private DateTime tgbd;
        public DateTime ptgbd
        {
            get { return ptgbd; }
            set { ptgbd = value; }
        }
        private int tghd;
        public int ptghd
        {
            get { return tghd; }
            set { tghd = value; }
        }
        public LichSu()
        {

        }
        public static DataSet getLichSu(DateTime date)
        {
            string[] paras = new string[] { "@user", "@day" };
            object[] values = new object[] { User.getUser().pid,date };
            return Models.Connection.FillDataSet("getHistoryinDay", CommandType.StoredProcedure, paras, values);
        }
     
     
        public static int KTChotCa()
        {
            return int.Parse(Models.Connection.ExcuteScalar("select dbo.CheckWorkProcess(" + User.getUser().pid+",'"+DateTime.Now.ToString()+"')"));
        }

        internal static DataSet getStaticalinDay(DateTime date)
        {
            string[] paras = new string[] { "@iduser", "@date" };
            object[] values = new object[] { User.getUser().pid, date };
            return Models.Connection.FillDataSet("getStaticalbyDay", CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet GetAmountofCustomerType(string v)
        {
            string[] paras = new string[] { "@id" };
            object[] values = new object[] {  v };
            return Models.Connection.FillDataSet("getTypeCustomerbyDay", CommandType.StoredProcedure, paras, values);
        }

        public static DataSet getminmaxyear()
        {
            return Models.Connection.FillDataSet("getminmaxyear", CommandType.StoredProcedure);
        }
        public static int ChotCa()
        {
            string[] paras = new string[] { "@user","@ngay" };
            object[] values = new object[] { User.getUser().pid,DateTime.Now };
            return Models.Connection.Excute_Sql("InsertWorkProcess", CommandType.StoredProcedure,paras,values);
        }

        internal static DataSet getStaticalInWeekofMonth(DataTable table)
        {
            string[] paras = new string[] { "@user", "@table" };
            object[] values = new object[] { User.getUser().pid, table };
            return Models.Connection.FillDataSet("getamountofCustomerbyWeekinMonth", CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet getTypeofCustomerinWeek(DateTime dateTime)
        {
            string[] paras = new string[] { "@date", "@user" };
            object[] values = new object[] { dateTime,User.getUser().pid };
            return Models.Connection.FillDataSet("getTypeCustomerinWeek", CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet getStaticalMonthinQuarter(int val, int year)
        {
            string[] paras = new string[] { "@user", "@quarter", "@year" };
            object[] values = new object[] { User.getUser().pid, val, year };
            return Models.Connection.FillDataSet("getAllHistoryinMonth", CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet getStaticalinMonthbyYear(int year)
        {
            string[] paras = new string[] { "@user", "@year" };
            object[] values = new object[] { User.getUser().pid, year };
            return Models.Connection.FillDataSet("getAllHistoryinMonthbyYear", CommandType.StoredProcedure, paras, values);
        }

        public static int getWeek()
        {
            try
            {
                return int.Parse(Models.Connection.ExcuteScalar("select dbo.GetNumberofWeek(" + User.getUser().pid + ")"));
            }
            catch
            {
                return 0;
            }
        }
        public static DataSet getAllStaticinYear(int year)
        {
            string[] paras = new string[] { "@user", "@year" };
            object[] values = new object[] { User.getUser().pid,year };
            return Models.Connection.FillDataSet("getStaticalineachDayinYear", CommandType.StoredProcedure, paras, values);
        }
        public static DataSet getSl(DateTime pass)
        {
            string[] paras = new string[] { "@pass", "@user" };
            object[] values = new object[] { pass,User.getUser().pid  };
            return Models.Connection.FillDataSet("GetnumberofCustomerinDayofWeek", CommandType.StoredProcedure,paras,values);
        }
        public static DataSet GetAllHistoryInMonth(int month,int year)
        {
            string[] paras = new string[] { "@user", "@month", "@year" };
            object[] values = new object[] { User.getUser().pid,month,year };
            return Models.Connection.FillDataSet("getAllHistoryinMonth", CommandType.StoredProcedure, paras, values);
        }
        public static DataSet getMonth()
        {
            return Models.Connection.FillDataSet("getmonthandyear", CommandType.StoredProcedure);
        }
        public static DataSet getSLKHinMonth(string a)
        {
            string[] paras = new string[] { "@user", "@month","@year" };
            object[] values = new object[] { User.getUser().pid,getMonth(a),getYearh(a) };
            return Models.Connection.FillDataSet("getallDayinMonth", CommandType.StoredProcedure, paras, values);
        }
        private static string getMonth(string a)
        {
            string month = "";
            for(int i=0;i<a.Length;i++)
            {
                if(a[i]=='/')
                {
                    return month;
                }
                else
                {
                    month += a[i];
                }
            }
            return "";
        }
        private static string getYearh(string a)
        {
            string month = "";
            for (int i = a.Length-1; i>=0; i--)
            {
                if (a[i] == '/')
                {
                    return Reverse(month);
                }
                else
                {
                    month += a[i];
                }
            }
            return "";
        }
        public static DataSet getStaticalinQuarter(int year)
        {
            string[] paras = new string[] { "@user", "@year" };
            object[] values = new object[] { User.getUser().pid,year };
            return Models.Connection.FillDataSet("getStaticalinQuarter", CommandType.StoredProcedure, paras, values);
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static DataSet getAllHistoryinQuarter(int quarter,int year)
        {
            string[] paras = new string[] { "@user", "@quarter", "@year" };
            object[] values = new object[] { User.getUser().pid, quarter,year };
            return Models.Connection.FillDataSet("getAllHistoryinQuater", CommandType.StoredProcedure, paras, values);
        }
    }
}
