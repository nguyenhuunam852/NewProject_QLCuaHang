using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1.Controllers
{
    class DatGheControllers
    {

        public static int InsertHoatDong(string idkh,string idghe)
        {
            Ghe ghe = new Ghe(idghe);
            return ghe.getStateInfo().InsertHoatDong(idkh);
        }
        public static DataSet laytinhtrangHoatDong(string idghe)
        {
            Ghe ghe = new Ghe(idghe);
            return ghe.laytthoatdong();
        }
        public static DataSet layDSHoatDong()
        {
            return Ghe.layDSHoatDong();
        }
        public static int Ketthucdatghe(string idghe,string idkh,string time)
        {
            Ghe ghe = new Ghe(idghe);
            int hour = int.Parse(time.Remove(2));
            time = time.Substring(3);
            int minute = int.Parse(time.Remove(2));
            time = time.Substring(3);
            int second = int.Parse(time);
            int max = 00 * 3600 + 30 * 60 + 00;
            int current = hour * 3600 + minute * 60 + second;
            int save = max - current;
            return ghe.getStateInfo().KetthucHoatDong(idkh,save); 
        }
        public string show(int save)
        {
            string shour = (save / 10000).ToString();
            save = save % 10000;
            string sminute = (save / 100).ToString();
            save = save % 100;
            string ssecond = save.ToString();
            string ssave = shour + ":" + sminute + ":" + ssecond;
            return ssave;
        }
     
    }
}
