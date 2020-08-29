using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class SettingsControllers
    {
        public static string getPathOfTxtFile()
        {
            string path = @""+Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "\\save\\");
            string file = "config.txt";
            string check = path + file;
            return check;
        }
        public static void WriteFileTxt(object[] param,object[] value)
        {
            string check = getPathOfTxtFile();
            StreamWriter sw = new StreamWriter(check);
            for(int i=0;i<param.Length;i++)
            {
                sw.WriteLine(param[i] + "@" + value[i]);
            }
            sw.Close();
        }
        public static void saveSettings()
        {
            string check = getPathOfTxtFile();
            StreamWriter sw = new StreamWriter(check);
            
            foreach (var k in Settings.getSettings().dic)
            {
                sw.WriteLine(k.Key + "@" + k.Value);
            }
            
            sw.Close();
        }
        public static Dictionary<string,string> getInformation()
        {
            return Settings.getInformation();
        }
        public static Dictionary<string, string> infor()
        {
            return Settings.getSettings().dic;
        }

        internal static int testConnect(string text1, string text2, string text3, string text4)
        {
            return Connection.testConnect(text1,text2,text3,text4);   
        }

        internal static void testConnect()
        {
            throw new NotImplementedException();
        }

        internal static int testConnect(string text)
        {
            return Connection.TestDataBase(text);
        }
    }
}
