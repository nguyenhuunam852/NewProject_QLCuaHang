using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Models
{
    class Settings
    {
        private string servername;
        public string pservername
        {
            get { return servername; }
            set { servername = value; }
        }
        private string databasename;
        public string pdatabasename
        {
            get { return databasename; }
            set { databasename = value; }
        }
        private string dv;
        public string pdonvi
        {
            get { return dv; }
            set { dv = value; }
        }
        private string tgbd;
        public string ptgbd
        {
            get { return tgbd; }
            set { tgbd = value; }
        }
        private string tghd;
        public string ptghd
        {
            get { return tghd; }
            set { tghd = value; }
        }
        private string tgkt;
        public string ptgkt
        {
            get { return tgkt; }
            set { tgkt = value; }
        }
        public Dictionary<string, string> dic ;

        public Settings()
        {

        }
        public static Settings setting;
        public static Settings getSettings()
        {
            if(setting==null)
            {
                setting= new Settings();
            }
            return setting;
        }
      

        public static Dictionary<string,string> getInformation()
        {
            setting = getSettings();
            setting.dic = new Dictionary<string, string>();
            string path=SettingsControllers.getPathOfTxtFile();
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] spl = line.Split('@');
                    setting.dic[spl[0]] = spl[1];
                }
            }
           
            setting.pservername = setting.dic["txtServerName"];
            setting.pdatabasename = setting.dic["txtDataBase"];
            setting.pdonvi = setting.dic["txtDV"];
            setting.ptgbd = setting.dic["txtTGBD"];
            setting.ptghd = setting.dic["txtTGHD"];
            setting.ptgkt = setting.dic["txtTGKT"];
            return setting.dic;
        }
        public static void setOBject()
        {

        }
        public void setVariable()
        {
            
        }
    }
}
