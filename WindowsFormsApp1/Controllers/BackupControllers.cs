using Microsoft.SqlServer.Management.Smo;
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
    class BackupControllers
    {
        public static int backupData(string text1)
        {
            BackUp bu = new BackUp(); 
            return bu.BackupDatabase(text1);
        }

        internal static int restoreData(string text, string text1, string text2)
        {
            BackUp bu = new BackUp();
            return bu.RestoreDatabase(text,text1,text2);
        }

        public static DataTable getDatabaseIfExist(string txtFileName, string txtFolder)
        {
            BackUp bu = new BackUp();
            return bu.getDTB(txtFileName, txtFolder);
        }

        internal static string getBase(string v)
        {
            return BackUp.getbase(v);
        }
    }
}
