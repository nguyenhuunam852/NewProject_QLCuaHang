﻿using System;
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
            string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "\\save\\");
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
        public static Dictionary<string,string> getInformation()
        {
            return Settings.getInformation();
        }
        public static Dictionary<string, string> infor()
        {
            return Settings.getSettings().dic;
        }
    }
}