using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class BackupControllers
    {
        public static int backupData()
        {
            BackUp bu = new BackUp(); 
            return bu.BackupDatabase();
        }

        internal static int restoreData(string text, string text1, string text2)
        {
            BackUp bu = new BackUp();
            return bu.RestoreDatabase(text,text1,text2);
        }
    }
}
