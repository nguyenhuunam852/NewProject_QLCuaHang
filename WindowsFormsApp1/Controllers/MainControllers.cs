using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class MainControllers
    {
        internal static int ReadFile()
        {
            string check = SettingsControllers.getPathOfTxtFile();
            if (!File.Exists(check))
            {
                File.Create(check);
                return 0;
            }
            if (new FileInfo(check).Length == 0)
            {
                return 0;
            }
            return 1;
        }

        internal static int checkExist(DateTime dt)
        {
           return LichSu.CheckExistStatical(dt);
                
        }

        internal static bool checkExist()
        {
            throw new NotImplementedException();
        }
    }
}
