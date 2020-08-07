using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class ThongKeControllers
    {
  
        public static int KTChotCa()
        {
            return LichSu.KTChotCa();
        }
        public static int ChotCa()
        {
            return LichSu.ChotCa();
        }
      
        public static DataSet getHistoryinDay(DateTime date)
        {
            return LichSu.getLichSu(date);
        }
        public static DataSet getMinYearandMaxYear()
        {
            return LichSu.getminmaxyear();
        }
        public static DataTable getSLKHinDay(DateTime pass )
        {
            return LichSu.getSl(pass).Tables[0];
        }
        public static DataTable getMonth()
        {
            return LichSu.getMonth().Tables[0];
        }
        public static DataSet getSLKHinQuarter(int year)
        {
            return LichSu.getStaticalinQuarter(year);
        }

        internal static DataSet getStaticinDay(DateTime dateTime)
        {
            return LichSu.getStaticalinDay(dateTime);
        }
        internal static DataSet getTempData(DateTime dateTime)
        {
            return LichSu.getTempSum(dateTime);
        }
        internal static DataTable getTypeCustomerbyDay(string v)
        {
            return LichSu.GetAmountofCustomerType(v).Tables[0];
        }

        public static DataSet getAllStaticalinYear(int year)
        {
            return LichSu.getAllStaticinYear(year);
        }

        internal static DataSet getStaticalInWeekofMonth(DataTable table)
        {
            return LichSu.getStaticalInWeekofMonth(table);
        }

        internal static DataSet getTypeOfCusmtomerinWeek(DateTime dateTime)
        {
            return LichSu.getTypeofCustomerinWeek(dateTime);
        }

        internal static DataSet getStaticalinEachMonth(string v)
        {
            return LichSu.GetStaticalInEachMonth(v);
        }

        internal static DataSet getTypeCustomerofMonth(int month, int year)
        {
            return LichSu.getTypeCustomerinMonth(month, year);
        }

        internal static DataSet getTypeCustomerofQuarter(int quarter, int year)
        {
            return LichSu.getTypeCustomerofQuarter(quarter, year);
        }

        internal static DataSet getTypeCustomerofYear(int year)
        {
            return LichSu.getTypeCustomerofYear(year);
        }
    }
}
